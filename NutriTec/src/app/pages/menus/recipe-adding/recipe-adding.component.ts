import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
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

  selectedProducts: any[] = [];
  searchResult: any[] = [];
  nombre: string = '';

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;
  recipeInfo: any = {
    tamano: 0,
    grasa: 0,
    sodio: 0,
    carbohidratos: 0,
    proteina: 0,
    calcio: 0,
    hierro: 0,
    energia: 0,
  };
  constructor(
    public me: MatDialogRef<RecipeAddingComponent>,
    private backend: BackendService,
    private swal: SwalService
  ) {}

  ngOnInit(): void {}
  getProductsId() {
    let response: string[] = [];
    this.selectedProducts.forEach((product) => {
      response.push(product.codigoBarras);
    });
    return response;
  }

  submit() {
    if (false) {
      this.swal.showError(
        'Error al ingresar los datos',
        'Datos ingresados insuficientes'
      );
      return;
    }

    const data = {
      nombre: this.nombre,
      correoCreador: 'mangel12412@gmail.com',
      productos: this.getProductsId(),
    };
    /**backend call here */
    console.log(data);

    this.backend.post_request('Receta/Crear', data).subscribe((response) => {
      this.swal.showSuccess(
        'Receta registrada!',
        'Prontamente, un administrador se encargará de validar esta receta'
      );
      this.me.close();
    });
  }

  openSearchBox() {
    this.searching = true;
  }

  searchProduct() {
    const data = {
      Codigo: '',
      desc: this.search,
    };
    this.searchResult = [];
    this.backend.get_request('Producto/buscar', data).subscribe((result) => {
      console.log(result);

      this.searchResult = result;
    });
  }

  selectSearchProduct(product: any) {
    this.selectedProducts.push(product);
    this.searching = false;
  }
  removeProduct(product: any) {
    this.selectedProducts.splice(this.selectedProducts.indexOf(product, 0), 1);
  }

  getTotalValue() {
    this.selectedProducts.forEach((product) => {
      this.recipeInfo.tamano += product.tamano;
      // recipeInfo.grasa+=product.grasa;
      this.recipeInfo.sodio += product.sodio;
      this.recipeInfo.carbohidratos += product.carbohidratos;
      this.recipeInfo.proteina += product.proteina;
      this.recipeInfo.calcio += product.calcio;
      this.recipeInfo.hierro += product.hierro;
      this.recipeInfo.energia += product.energia;
    });
  }
  async autoComplete() {
    this.nombre = 'Sopa de maiz';
    const data = {
      Codigo: '',
      desc: '',
    };
    this.searchResult = [];
    this.backend.get_request('Producto/buscar', data).subscribe((result) => {
      this.selectedProducts = result;
    });
  }
}
