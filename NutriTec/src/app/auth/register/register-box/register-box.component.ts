import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { UserService } from 'src/app/services/userService';

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
    private backend: BackendService,
    private router: Router,
    private userService: UserService
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
        this.login(data.correo, data.contra);
      });
    }
    if (this.userType == 2) {
      this.backend
        .post_request('Crear/Nutricionista', data)
        .subscribe((response) => {
          this.login(data.correo, data.contra);
          this.swal.showSuccess('Bienvenido', 'Te has registrado con éxito');
        });
    }
  }

  selectPay(value: number) {
    this.currentPayTypeIndex = value;
  }

  login(correo: string, contra: string) {
    const info = {
      correo: correo,
      contra: contra,
    };

    if (correo === '' || contra === '') {
      this.swal.showError('error', 'datos insuficientes');
      return;
    }

    this.backend.get_request('Login/Client', info).subscribe((user) => {
      if (
        user === null ||
        user === undefined ||
        JSON.stringify(user) === JSON.stringify([])
      ) {
        this.backend
          .get_request('Login/Nutricionista', info)
          .subscribe((doctor) => {
            if (
              doctor === null ||
              doctor === undefined ||
              JSON.stringify(doctor) === JSON.stringify([])
            ) {
              this.backend
                .get_request('Login/Admin', info)
                .subscribe((admin) => {
                  if (
                    admin === null ||
                    admin === undefined ||
                    JSON.stringify(admin) === JSON.stringify([])
                  ) {
                    this.swal.showError(
                      'Oops',
                      'El usuario no se encuentra en la base de datos '
                    );
                    return;
                  } else {
                    this.userService.user = false;
                    this.userService.doctor = false;
                    this.userService.admin = true;

                    localStorage.setItem('user', JSON.stringify(admin));

                    localStorage.setItem('userType', 'admin');

                    this.router.navigateByUrl('pages');
                  }
                });
            } else {
              this.userService.user = false;
              this.userService.doctor = true;
              this.userService.admin = false;
              localStorage.setItem('user', JSON.stringify(doctor));
              localStorage.setItem('userType', 'doctor');
              this.router.navigateByUrl('pages');
            }
          });
      } else {
        this.userService.user = true;
        this.userService.doctor = false;
        this.userService.admin = false;
        localStorage.setItem('userType', 'user');
        localStorage.setItem('user', JSON.stringify(user));

        this.router.navigateByUrl('pages');
      }
    });
  }
}
