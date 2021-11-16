import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { completerService } from 'src/app/services/completerService';
import { UserService } from 'src/app/services/userService';
import { RegisterBoxComponent } from './register-box/register-box.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  constructor(public dialog: MatDialog, public comp: completerService) {}

  name = '';
  lastName = '';
  address = '';
  password = '';
  passwordConfirm = '';

  userType: number = -1;
  dialogIsOpen: boolean = false;
  ngOnInit(): void {}
  nextRegistrationStep() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(RegisterBoxComponent, {
      width: 'auto',
      data: {
        address: this.address,
        password: this.password,
        name: this.name,
        lastName: this.lastName,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }

  autoComplete() {
    if (this.dialogIsOpen) return;
    this.name = this.comp.getWord();
    this.lastName = this.comp.getWord();
    this.address = this.comp.getWord() + '@gmail.com';
    this.password = this.comp.getWord();
    this.passwordConfirm = this.password;

    console.log(this.address + '\n' + this.password);
  }
}
