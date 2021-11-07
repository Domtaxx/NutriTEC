import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-measures',
  templateUrl: './measures.component.html',
  styleUrls: ['./measures.component.css'],
})
export class MeasuresComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  measures: any[] = [
    {
      date: '123',
      measures: [
        {
          name: 'Peso',
          value: 32,
        },
        {
          name: 'IMC',
          value: 32,
        },
        {
          name: 'Músculo',
          value: 62,
        },
        {
          name: 'Grasa',
          value: 44,
        },
        {
          name: 'Grasa',
          value: 44,
        },
        {
          name: 'Cintura',
          value: 44,
        },
        {
          name: 'Cuello',
          value: 34,
        },
        {
          name: 'Caderas',
          value: 124,
        },
      ],
    },
    {
      date: '123',
      measures: [
        {
          name: 'Peso',
          value: 32,
        },
        {
          name: 'IMC',
          value: 32,
        },
        {
          name: 'Músculo',
          value: 62,
        },
        {
          name: 'Grasa',
          value: 44,
        },
        {
          name: 'Grasa',
          value: 44,
        },
        {
          name: 'Cintura',
          value: 44,
        },
        {
          name: 'Cuello',
          value: 34,
        },
        {
          name: 'Caderas',
          value: 124,
        },
      ],
    },
    {
      date: '123',
      measures: [
        {
          name: 'Peso',
          value: 32,
        },
        {
          name: 'IMC',
          value: 32,
        },
        {
          name: 'Músculo',
          value: 62,
        },
        {
          name: 'Grasa',
          value: 44,
        },
        {
          name: 'Grasa',
          value: 44,
        },
        {
          name: 'Cintura',
          value: 44,
        },
        {
          name: 'Cuello',
          value: 34,
        },
        {
          name: 'Caderas',
          value: 124,
        },
      ],
    },
  ];
  today: boolean = true;
  history: boolean = false;

  //todayVars

  constructor(
    public me: MatDialogRef<MeasuresComponent>,
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
      'Receta registrada!',
      'Prontamente, un administrador se encargará de validar esta receta'
    );
    this.me.close();
  }

  openToday() {
    this.today = true;
    this.history = false;
  }
  openHistory() {
    this.today = false;
    this.history = true;
  }

  autoComplete() {}
}
