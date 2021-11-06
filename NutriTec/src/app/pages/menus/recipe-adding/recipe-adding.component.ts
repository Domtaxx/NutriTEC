import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-recipe-adding',
  templateUrl: './recipe-adding.component.html',
  styleUrls: ['./recipe-adding.component.css'],
})
export class RecipeAddingComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  products: any[] = [
    {
      pname: 'arroz',
      tamano: 12,
      energia: 133,
      grasa: 433,
    },
    {
      pname: 'azucar',
      tamano: 1,
      energia: 4443,
      grasa: 0,
    },
    {
      pname: 'arandanos',
      tamano: 4,
      energia: 43,
      grasa: 0,
    },
    {
      pname: 'jamon',
      tamano: 32,
      energia: 43,
      grasa: 43,
    },
    {
      pname: 'pasta',
      tamano: 62,
      energia: 763,
      grasa: 73,
    },
    {
      pname: 'lechuga',
      tamano: 87,
      energia: 77,
      grasa: 67,
    },
    {
      pname: 'leche',
      tamano: 2,
      energia: 2,
      grasa: 4,
    },
  ];
  selectedProducts: any[] = [];
  searchResult: any[] = [];

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;

  constructor(
    public me: MatDialogRef<RecipeAddingComponent>,
    private swal: SwalService
  ) {}

  ngOnInit(): void {}

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

  openSearchBox() {
    this.searching = true;
  }

  searchProduct() {
    //this.search
    console.log(this.products);

    this.searchResult = [];
    for (let i = 0; i < this.products.length; i++) {
      if (this.products[i].pname === this.search) {
        this.searchResult.push(this.products[i]);
        continue;
      }
      if (this.products[i].pname[0] === this.search[0]) {
        this.searchResult.push(this.products[i]);
        continue;
      }
    }
  }

  selectSearchProduct(product: any) {
    this.selectedProducts.push(product);
    this.searching = false;
  }
  removeProduct(product: any) {
    this.selectedProducts.splice(this.selectedProducts.indexOf(product, 0), 1);
  }
  autoComplete() {
    this.selectedProducts = this.products.slice();
  }
}
