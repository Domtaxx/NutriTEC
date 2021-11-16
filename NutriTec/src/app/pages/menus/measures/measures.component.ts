import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { UserService } from 'src/app/services/userService';

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

  measures: any[] = [];
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
    private swal: SwalService,
    private backend: BackendService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public uServ: UserService
  ) {}

  ngOnInit(): void {
    if (this.uServ.doctor) {
      this.today = false;
      this.history = true;
    }

    let user;
    if (!this.data.user)
      user = JSON.parse(localStorage.getItem('user') as string)[0];
    else user = this.data.user;
    const data = {
      correo: user.correo,
    };

    console.log(data);

    this.backend
      .get_request('Cliente/Medidas/Todas', data)
      .subscribe((result) => {
        this.measures = result;
        console.log(result);

        this.measures.forEach((value) => {
          const dateString: string = (value.fecha as Date).toString();

          value.fecha = dateString.substring(dateString.indexOf('T'), -1);
        });
      });
  }
  randomDate() {
    return new Date(
      new Date(2012, 0, 1).getTime() +
        Math.random() * (new Date().getTime() - new Date(2012, 0, 1).getTime())
    );
  }
  submit() {
    let user;
    if (!this.data.user)
      user = JSON.parse(localStorage.getItem('user') as string)[0];
    else user = this.data.user;

    const data = {
      fecha: this.randomDate(),
      peso: this.peso,
      imc: this.imc,
      porcentajeGrasa: this.grasa,
      porcentajeMusculo: this.musculo,
      correoCliente: user.correo,
      cintura: this.cintura,

      cuello: this.cuello,
      cadera: this.caderas,
    };
    console.log(data);

    if (
      this.peso > 0 &&
      this.grasa > 0 &&
      this.imc > 0 &&
      this.musculo > 0 &&
      this.caderas > 0 &&
      this.cuello > 0 &&
      this.cintura > 0
    ) {
      {
      }

      /**backend call here */
      this.backend.post_request('Cliente/Medidas', data).subscribe((result) => {
        console.log(result);

        this.swal.showSuccess(
          'Medición registrada!',
          'Esta medición fue registrada con éxito'
        );
        this.me.close();
        return;
      });
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
