import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SwalService } from './services/swalService';
import { BackendService } from './services/backend-service.service';
import { HttpClientModule } from '@angular/common/http';
import { completerService } from './services/completerService';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatePipe } from '@angular/common';
@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatFormFieldModule,
  ],
  providers: [SwalService, BackendService, completerService, DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
