import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ComService } from 'src/app/services/comService';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-recipe-approving',
  templateUrl: './recipe-approving.component.html',
  styleUrls: ['./recipe-approving.component.css'],
})
export class RecipeApprovingComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  products: any[] = [
    {
      pname: 'arroz',
      tamano: 12,
      energia: 133,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 433,
      code: 123123,
    },
    {
      pname: 'azucar',
      tamano: 1,
      energia: 4443,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 0,
      code: 4443,
    },
    {
      pname: 'arandanos',
      tamano: 4,
      energia: 43,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 0,
      code: 1676123,
    },
    {
      pname: 'jamon',
      tamano: 32,
      energia: 43,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 43,
      code: 777123,
    },
    {
      pname: 'pasta',
      tamano: 62,
      energia: 763,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 73,
      code: 67673123,
    },
    {
      pname: 'lechuga',
      tamano: 87,
      energia: 77,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 67,
      code: 6763,
    },
    {
      pname: 'leche',
      tamano: 2,
      energia: 2,
      hierro: 123,
      sodio: 343,
      carbohidratos: 12,
      calcio: 12,
      proteina: 11,
      grasa: 4,
      code: 781,
    },
  ];

  constructor(
    public me: MatDialogRef<RecipeApprovingComponent>,
    private swal: SwalService,
    private com: ComService
  ) {}

  ngOnInit(): void {
    this.autoComplete();
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
