import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';
import { jsPDF } from 'jspdf';
import { DatePipe } from '@angular/common';
import { BackendService } from 'src/app/services/backend-service.service';
@Component({
  selector: 'app-bill-manage',
  templateUrl: './bill-manage.component.html',
  styleUrls: ['./bill-manage.component.css'],
})
export class BillManageComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }
  @ViewChild('content') content!: ElementRef;
  Semanal: boolean = true;
  Mensual: boolean = false;
  Anual: boolean = false;

  semanalDoctors: any[] = [];

  mensualDoctors: any[] = [];

  anualDoctors: any[] = [];

  constructor(
    public me: MatDialogRef<BillManageComponent>,
    private swal: SwalService,
    private datePipe: DatePipe,
    private backend: BackendService
  ) {}

  ngOnInit(): void {
    this.backend
      .get_request('ReporteCobro', { tipo: 'Mensual' })
      .subscribe((result) => {
        this.mensualDoctors = result;
      });

    this.backend
      .get_request('ReporteCobro', { tipo: 'Semanal' })
      .subscribe((result) => {
        this.semanalDoctors = result;
      });

    this.backend
      .get_request('ReporteCobro', { tipo: 'Anual' })
      .subscribe((result) => {
        this.anualDoctors = result;
      });
  }

  submit() {
    (document.getElementById('content') as HTMLElement).style.display = '';
    const doc = new jsPDF('p', 'pt', 'a4');
    doc.html(document.getElementById('content') as HTMLElement, {
      callback: function (doc) {
        doc.save();
      },
    });

    console.log(this.content);

    this.swal.showSuccess(
      'Cobros generados',
      'Los cobros se realizaron con éxito'
    );
    this.me.close();
  }

  autoComplete() {}
  openSemanal() {
    this.Semanal = true;
    this.Anual = false;
    this.Mensual = false;
  }

  openMensual() {
    this.Semanal = false;
    this.Anual = false;
    this.Mensual = true;
  }
  openAnual() {
    this.Semanal = false;
    this.Anual = true;
    this.Mensual = false;
  }

  getDate() {
    return this.datePipe.transform(new Date(), 'yyyy-MM-dd');
  }
}
