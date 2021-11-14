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

  products: any[] = [
    {
      tamano: 12,
      energia: 133,
      grasa: 433,
      codigoBarras: '7501000608249',
      descripcion: 'GALLETA SALADITA GAMESA 1024GR',
    },
  ];
  selectedProducts: any[] = [];
  searchResult: any[] = [];
  nombre: string = '';

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;

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

    this.backend.post_request('Cliente/Receta', data).subscribe((response) => {
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
    //this.search
    console.log(this.products);

    this.searchResult = [];
    for (let i = 0; i < this.products.length; i++) {
      if (
        this.products[i].pname.toLocaleLowerCase() ===
        this.search.toLocaleLowerCase()
      ) {
        this.searchResult.push(this.products[i]);
        continue;
      }
      if (
        this.products[i].pname[0].toLocaleLowerCase() ===
        this.search[0].toLocaleLowerCase()
      ) {
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
    this.nombre = 'Sopa de maiz';
  }
}
