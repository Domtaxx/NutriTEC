import { Component, HostListener, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { DatePipe } from '@angular/common';
import { jsPDF } from 'jspdf';
@Component({
  selector: 'app-my-advance',
  templateUrl: './my-advance.component.html',
  styleUrls: ['./my-advance.component.css'],
})
export class MyAdvanceComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  from: any;
  to: any;

  reports: any[] = [];

  constructor(
    public me: MatDialogRef<MyAdvanceComponent>,
    private backend: BackendService,
    private swal: SwalService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {}
  dateChange(from: any, to: any) {
    if (from != null) {
      this.from = from;
    }
    if (to != null) {
      this.to = to;
    }

    if (this.from && this.to) {
      const user = JSON.parse(localStorage.getItem('user') as string)[0];

      const data = {
        correo: user.correo,

        FechaI: this.datePipe.transform(this.from, 'yyyy-MM-dd'),
        FechaF: this.datePipe.transform(this.to, 'yyyy-MM-dd'),
      };

      this.backend
        .get_request('Cliente/Medidas/Periodo', data)
        .subscribe((reports: any) => {
          reports.forEach((report: any) => {
            const rep = {
              fecha: this.datePipe.transform(report.fecha, 'yyyy-MM-dd'),

              cintura: report.cintura,
              porcentajeMusculo: report.porcentajeMusculo,
              porcentajeGrasa: report.porcentajeGrasa,
            };
            this.reports.push(rep);
          });
        });
    }
  }
  download() {
    (document.getElementById('content') as HTMLElement).style.display = '';
    const doc = new jsPDF('p', 'pt', 'a4');
    doc.html(document.getElementById('content') as HTMLElement, {
      callback: function (doc) {
        doc.save();
      },
    });

    (document.getElementById('content') as HTMLElement).style.display =
      'hidden';
  }

  async autoComplete() {
    const data = {
      Codigo: '',
      desc: '',
    };
    this.backend.get_request('Producto/buscar', data).subscribe((result) => {
      this.reports = result;
    });
  }

  getDates() {
    return {
      FechaI: this.datePipe.transform(this.from, 'yyyy-MM-dd'),
      FechaF: this.datePipe.transform(this.to, 'yyyy-MM-dd'),
    };
  }
}
