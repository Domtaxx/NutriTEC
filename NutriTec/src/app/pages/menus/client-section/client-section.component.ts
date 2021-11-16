import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { ComService } from 'src/app/services/comService';
import { SwalService } from 'src/app/services/swalService';
import { RecipeAddingComponent } from '../recipe-adding/recipe-adding.component';

@Component({
  selector: 'app-client-section',
  templateUrl: './client-section.component.html',
  styleUrls: ['./client-section.component.css'],
})
export class ClientSectionComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') this.autoComplete();
  }

  myclients: any[] = [];
  searchResult: any[] = [];

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;

  constructor(
    public me: MatDialogRef<ClientSectionComponent>,
    private swal: SwalService,
    private com: ComService,
    private backend: BackendService
  ) {}

  ngOnInit(): void {
    this.getMyClients();
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

  openSearchBox() {
    this.searching = true;
  }

  openClientMealHistory(client: any) {
    this.com.homeComp.openNutriPlanDoctor(client);
  }
  openClientMeasureHistory(client: any) {
    this.com.homeComp.openMeasuresDoctor(client);
  }
  autoComplete() {}

  searchUser() {
    //this.search
    this.backend
      .get_request('/Crear/Cliente', null)
      .subscribe((clients: any[]) => {
        this.searchResult = [];
        for (let i = 0; i < clients.length; i++) {
          if (
            clients[i].primerNom.toLocaleLowerCase() ===
            this.search.toLocaleLowerCase()
          ) {
            this.searchResult.push(clients[i]);
            continue;
          }
          if (
            clients[i].primerNom[0].toLocaleLowerCase() ===
            this.search[0].toLocaleLowerCase()
          ) {
            this.searchResult.push(clients[i]);
            continue;
          }
        }
        console.log(this.searchResult);
      });
  }

  selectSearchClient(product: any) {
    //this.myclients.push(product);
    const user = JSON.parse(localStorage.getItem('user') as string)[0];
    const data = {
      correoCliente: product.correo,
      correoNutricionista: user.correo,
    };

    this.backend
      .post_request('Nutricionista/Clientes', data)
      .subscribe((response) => {
        this.searching = false;
        this.getMyClients();
      });
  }
  removeClient(client: any) {
    const data = {
      Correo_cliente: client.correo,
    };
    console.log(client);

    this.backend
      .delete_request('Nutricionista/Clientes', data)
      .subscribe((response) => {
        this.swal.showSuccess(
          'Cliente desasociado',
          'proceso realizado con éxito'
        );
        this.me.close();
      });
  }

  getMyClients() {
    const user = JSON.parse(localStorage.getItem('user') as string)[0];
    const data = {
      Correo_nutri: user.correo,
    };
    this.backend
      .get_request('Nutricionista/Clientes', data)
      .subscribe((result) => {
        this.myclients = result;
        console.log(this.myclients);
      });
  }
}
