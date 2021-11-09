import { Injectable } from '@angular/core';
import { HomeComponent } from '../pages/home/home.component';
@Injectable({
  providedIn: 'root',
})
export class ComService {
  homeComp!: HomeComponent;
}
