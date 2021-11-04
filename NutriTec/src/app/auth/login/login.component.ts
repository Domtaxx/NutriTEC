import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';

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
    private backend: BackendService
  ) {}

  userId: string = '';
  password: string = '';

  ngOnInit(): void {}
  toRegister() {
    this.router.navigateByUrl('auth/register');
  }

  login() {
    console.log('JOA');

    const info = {
      username: this.userId,
      password: this.password,
    };
    if (this.userId === '' || this.password === '') {
      this.swal.showError('error', 'datos insuficientes');
      return;
    }
    this.backend.post_request('Login', info).subscribe((user) => {
      //console.log(user);

      if (user === null || user === undefined) {
        this.backend.post_request('Admin/Login', info).subscribe((admin) => {
          if (admin === null || admin === undefined) {
            this.swal.showError(
              'Oops',
              'El usuario no se encuentra en la base de datos '
            );
            return;
          } else {
            localStorage.setItem('admin', 'true');
            this.router.navigateByUrl('admin');
          }
        });
      } else {
        localStorage.setItem('user', JSON.stringify(user));
        this.router.navigateByUrl('pages');
      }
    });
  }

  autoComplete() {
    this.userId = 'Adriantec';
    this.password = '123';
  }
}
