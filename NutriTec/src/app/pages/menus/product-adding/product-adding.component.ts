import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-product-adding',
  templateUrl: './product-adding.component.html',
  styleUrls: ['./product-adding.component.css'],
})
export class ProductAddingComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  codBarras: string = '';
  descripcion: string = '';
  grasa: number = 0;
  hierro: number = 0;
  carbohidratos: number = 0;
  sodio: number = 0;
  energia: number = 0;
  proteina: number = 0;
  calcio: number = 0;
  tamano: number = 0;

  constructor(
    public me: MatDialogRef<ProductAddingComponent>,
    private backend: BackendService,
    private swal: SwalService
  ) {}

  ngOnInit(): void {}

  submit() {
    if (this.codBarras === '' || this.descripcion === '') {
      this.swal.showError(
        'Error al ingresar los datos',
        'Datos ingresados insuficientes'
      );
      return;
    }

    const data = {
      codigoBarras: this.codBarras,
      descripcion: this.descripcion,
      grasa: this.grasa,
      hierro: this.hierro,
      carbohidratos: this.carbohidratos,
      sodio: this.sodio,
      energia: this.energia,
      proteina: this.proteina,
      calcio: this.calcio,
      tamano: this.tamano,
      vitaminas: 1,
    };
    console.log(data);

    this.backend.post_request('Producto/buscar', data).subscribe((response) => {
      this.swal.showSuccess(
        'Producto registrado!',
        'Prontamente, un administrador se encargará de validar este producto'
      );
      this.me.close();
    });
  }

  autoComplete() {
    this.codBarras = '7A4AEEEE663';
    this.descripcion = 'Torta de carne alta en proteina';
    this.grasa = 76;
    this.hierro = 76;
    this.carbohidratos = 66;
    this.sodio = 20;
    this.energia = 55;
    this.proteina = 91;
    this.calcio = 10;
    this.tamano = 120;
  }
}
