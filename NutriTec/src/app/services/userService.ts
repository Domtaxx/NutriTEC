import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user: boolean = true;
  admin: boolean = false;
  doctor: boolean = false;

  swithUserType() {
    if (this.user) {
      this.user = false;
      this.admin = true;
      return;
    }
    if (this.admin) {
      this.admin = false;
      this.doctor = true;
      return;
    }
    if (this.doctor) {
      this.doctor = false;
      this.user = true;
      return;
    }
  }
  getUser() {
    return localStorage.getItem('user');
  }
}
