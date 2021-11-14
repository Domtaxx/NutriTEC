import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-register-box',
  templateUrl: './register-box.component.html',
  styleUrls: ['./register-box.component.css'],
})
export class RegisterBoxComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  constructor(
    @Inject(MAT_DIALOG_DATA) public registerInfo: any,
    private swal: SwalService,
    private backend: BackendService
  ) {}

  currentPayTypeIndex = -1;
  payType: any[] = [
    { type: 'anual' },
    { type: 'mensual' },
    { type: 'semanal' },
  ];

  userType: number = -1;
  peso: number = 0;
  imc: number = 0;
  grasa: number = 0;
  musculo: number = 0;

  cintura: number = 0;
  cuello: number = 0;
  caderas: number = 0;
  ngOnInit(): void {}

  autoComplete() {
    this.peso = 80;
    this.imc = 18.5;
    this.grasa = 15;
    this.musculo = 20;

    this.cintura = 50;
    this.cuello = 30;
    this.caderas = 70;
  }

  selectUser(type: number) {
    this.userType = type;
  }
  submit() {
    const data = {
      correo: this.registerInfo.address,
      contra: this.registerInfo.password,
      direccion: '',
      primerNom: this.registerInfo.name,
      segNom: '',
      primerApellido: this.registerInfo.lastName,
      segApellido: '',
      maxCalorias: 0,
      fechaNace: new Date(),
      peso: 0,
      imc: 0,
    };
    console.log(data);
    if (this.userType == 1) {
      this.backend.post_request('Crear/Cliente', data).subscribe((response) => {
        this.swal.showSuccess('Bienvenido', 'Te has registrado con éxito');
      });
    }
    if (this.userType == 2) {
      this.backend
        .post_request('Crear/Nutricionista', data)
        .subscribe((response) => {
          this.swal.showSuccess('Bienvenido', 'Te has registrado con éxito');
        });
    }
  }

  selectPay(value: number) {
    this.currentPayTypeIndex = value;
  }
}
