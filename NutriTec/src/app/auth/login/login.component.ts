import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { UserService } from 'src/app/services/userService';
import { Md5 } from 'ts-md5/dist/md5';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }
  constructor(
    private router: Router,
    private swal: SwalService,
    private backend: BackendService,
    private userService: UserService
  ) {}

  userId: string = '';
  password: string = '';
  devUserindex = 0;

  ngOnInit(): void {}
  toRegister() {
    this.router.navigateByUrl('auth/register');
  }

  login() {
    const info = {
      correo: this.userId,
      contra: Md5.hashStr(this.password),
    };

    if (this.userId === '' || this.password === '') {
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

  autoComplete() {
    //Para usuarios
    this.devUserindex += 1;
    if (this.devUserindex == 1) {
      this.userId = 'mangel12412@gmail.com';
      this.password = '123';
    }
    if (this.devUserindex == 2) {
      this.userId = 'Fernando03@gmail.com';
      this.password = '123';
    }

    if (this.devUserindex == 3) {
      this.userId = 'Admin1@gmail.com';
      this.password = 'Admin123';
    }

    if (this.devUserindex > 3) this.devUserindex = 0;
  }
}
