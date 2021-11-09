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
      date: '12/12/12',
      peso: 32,
      imc: 32,
      musculo: 62,
      grasa: 44,
      cintura: 44,
      cuello: 34,
      caderas: 124,
    },
    {
      date: '13/12/12',
      peso: 36,
      imc: 22,
      musculo: 12,
      grasa: 54,
      cintura: 34,
      cuello: 24,
      caderas: 114,
    },
  ];
  today: boolean = true;
  history: boolean = false;

  peso: number = 0;
  imc: number = 0;
  grasa: number = 0;
  musculo: number = 0;

  cintura: number = 0;
  cuello: number = 0;
  caderas: number = 0;

  //todayVars

  constructor(
    public me: MatDialogRef<MeasuresComponent>,
    private swal: SwalService
  ) {}

  ngOnInit(): void {}

  submit() {
    if (
      this.peso > 0 &&
      this.grasa > 0 &&
      this.imc > 0 &&
      this.musculo > 0 &&
      this.caderas > 0 &&
      this.cuello > 0 &&
      this.caderas > 0 &&
      this.cintura > 0
    ) {
      const data = {
        date: new Date(),
        peso: this.peso,
        imc: this.imc,
        grasa: this.grasa,
        musculo: this.musculo,

        cintura: this.cintura,
        cuello: this.cuello,
        caderas: this.caderas,
      };
      /**backend call here */

      this.swal.showSuccess(
        'Medición registrada!',
        'Esta medición fue registrada con éxito'
      );
      this.me.close();
    } else {
      this.swal.showError(
        'Error al ingresar los datos',
        'Datos ingresados insuficientes'
      );
      return;
    }
  }

  openToday() {
    this.today = true;
    this.history = false;
  }
  openHistory() {
    this.today = false;
    this.history = true;
  }

  autoComplete() {
    this.peso = 70;
    this.imc = 20;
    this.grasa = 30;
    this.musculo = 60;

    this.cintura = 122;
    this.cuello = 32;
    this.caderas = 50;
  }
}
