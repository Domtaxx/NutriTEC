import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user: boolean = false;
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

  constructor() {
    const userT = this.getUserType();
    switch (userT) {
      case 'admin': {
        this.admin = true;
        break;
      }
      case 'doctor': {
        this.doctor = true;
        break;
      }
      case 'user': {
        this.user = true;
        break;
      }
      default: {
        break;
      }
    }
  }
  getUserType() {
    return localStorage.getItem('userType');
  }
  getUser() {
    return localStorage.getItem('user');
  }
}
