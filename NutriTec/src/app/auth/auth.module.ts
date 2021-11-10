import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { MatDialogModule } from '@angular/material/dialog';
import { RegisterBoxComponent } from './register/register-box/register-box.component';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, RegisterBoxComponent],
  imports: [CommonModule, MatIconModule, MatDialogModule, AuthRoutingModule],
})
export class AuthModule {}
