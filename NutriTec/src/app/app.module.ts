import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SwalService } from './services/swalService';
import { BackendService } from './services/backend-service.service';
import { HttpClientModule } from '@angular/common/http';
import { completerService } from './services/completerService';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [SwalService, BackendService, completerService],
  bootstrap: [AppComponent],
})
export class AppModule {}
