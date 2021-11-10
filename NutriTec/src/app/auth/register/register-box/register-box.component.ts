import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register-box',
  templateUrl: './register-box.component.html',
  styleUrls: ['./register-box.component.css'],
})
export class RegisterBoxComponent implements OnInit {
  userType: number = -1;
  constructor() {}
  peso: number = 0;
  imc: number = 0;
  grasa: number = 0;
  musculo: number = 0;

  cintura: number = 0;
  cuello: number = 0;
  caderas: number = 0;
  ngOnInit(): void {}

  selectUser(type: number) {
    this.userType = type;
  }
  submit() {}
}
