import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
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

  products: any[] = [];
  compositeProducts: any[] = [
    {
      descripcion: 'Arroz integral',
    },
    {
      descripcion: 'Arroz integral',
    },
    {
      descripcion: 'Arroz integral',
    },
    {
      descripcion: 'Arroz integral',
    },
  ];
  constructor(
    public me: MatDialogRef<RecipeApprovingComponent>,
    private swal: SwalService,
    private com: ComService,
    private backend: BackendService
  ) {}

  ngOnInit(): void {
    this.autoComplete();
    this.backend.get_request('Recetas', null).subscribe((response) => {
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
    this.products.splice(this.products.indexOf(thing), 1);
  }
  disaprove(thing: any) {
    this.products.splice(this.products.indexOf(thing), 1);
  }
  autoComplete() {}
}
