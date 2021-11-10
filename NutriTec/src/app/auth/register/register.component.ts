import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RegisterBoxComponent } from './register-box/register-box.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  userType: number = -1;
  dialogIsOpen: boolean = false;
  ngOnInit(): void {}
  nextRegistrationStep() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(RegisterBoxComponent, {
      width: 'auto',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }
}
