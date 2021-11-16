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
    this.backend.get_request('Recetas', null).subscribe((response) => {
      this.products = response;
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
    this.products.splice(this.products.indexOf(thing), 1);
  }
  disaprove(thing: any) {
    this.products.splice(this.products.indexOf(thing), 1);
  }
  autoComplete() {}
}
