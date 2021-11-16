import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css'],
})
export class PagesComponent implements OnInit {
  constructor(private router: Router, private uS: UserService) {}
  userId: string = '';
  ngOnInit(): void {
    const user = JSON.parse(localStorage.getItem('user') as string)[0];
    if (this.uS.user) this.userId = user.primerNom + ' ' + user.primerApellido;

    if (this.uS.doctor)
      this.userId = user.primerNom + ' ' + user.primerApellido;

    if (this.uS.admin) this.userId = 'Administrador';
  }
  logout() {
    this.router.navigateByUrl('/auth');
    localStorage.removeItem('user');
  }
}
