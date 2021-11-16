import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';

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

  Semanal: boolean = true;
  Mensual: boolean = false;
  Anual: boolean = false;

  semanalDoctors: any[] = [
    {
      name: 'Ana lopez Gonzalez',
      billtype: 'semanal',
      pacients: 15,
      descount: 0,
      total: 15000,
    },
    {
      name: 'Pedro Gonzalez',
      billtype: 'semanal',
      pacients: 3,
      descount: 0,
      total: 4000,
    },
  ];

  mensualDoctors: any[] = [
    {
      name: 'Ana fd Gonzalez',
      billtype: 'anual',
      pacients: 15,
      descount: 0,
      total: 400,
    },
    {
      name: 'sds asdasd',
      billtype: 'anual',
      pacients: 3,
      descount: 0,
      total: 300,
    },
  ];

  anualDoctors: any[] = [
    {
      name: 'Ana lopez Gonzalez',
      billtype: 'mensual',
      pacients: 15,
      descount: 0,
      total: 15000,
    },
    {
      name: 'Pedro Gonzalez',
      billtype: 'mensual',
      pacients: 3,
      descount: 0,
      total: 4000,
    },
  ];

  constructor(
    public me: MatDialogRef<BillManageComponent>,
    private swal: SwalService
  ) {}

  ngOnInit(): void {}

  submit() {
    if (false) {
      this.swal.showError(
        'Error al ingresar los datos',
        'Datos ingresados insuficientes'
      );
      return;
    }

    const data = {};
    /**backend call here */

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
}
