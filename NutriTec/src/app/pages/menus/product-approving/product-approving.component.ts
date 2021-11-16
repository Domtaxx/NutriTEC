import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { ComService } from 'src/app/services/comService';
import { SwalService } from 'src/app/services/swalService';
import { ProductAddingComponent } from '../product-adding/product-adding.component';

@Component({
  selector: 'app-product-approving',
  templateUrl: './product-approving.component.html',
  styleUrls: ['./product-approving.component.css'],
})
export class ProductApprovingComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  products: any[] = [];

  constructor(
    public me: MatDialogRef<ProductAddingComponent>,
    private swal: SwalService,
    private com: ComService,
    private backend: BackendService
  ) {}

  ngOnInit(): void {
    this.autoComplete();
    this.getProductos();
  }
  getProductos() {
    this.products = [];
    this.backend.get_request('Productos', null).subscribe((response) => {
      this.products = response;
      console.log(response);
    });
  }
  submit() {
    if (false) {
      this.swal.showError(
        'Error al ingresar los datos',
        'Datos ingresados insuficientes'
      );
      return;
    }

    const data = {};
    /**backend call here */

    this.swal.showSuccess(
      'Receta registrada!',
      'Prontamente, un administrador se encargará de validar esta receta'
    );
    this.me.close();
  }

  aprove(thing: any) {
    let user = JSON.parse(localStorage.getItem('user') as string)[0];

    thing.correoAdmin = user.correo;
    thing.estado = 'Disponible';
    console.log(thing);

    this.backend.put_request('Productos', thing).subscribe((result) => {
      this.swal.showSuccess('Exito', 'El producto ser ha aprobado');
      this.getProductos();
    });
  }
  disaprove(thing: any) {
    this.products.splice(this.products.indexOf(thing), 1);
  }
  autoComplete() {}
}
