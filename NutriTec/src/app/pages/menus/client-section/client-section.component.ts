import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
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

  clients: any[] = [
    {
      name: 'pepe',
      mail: 'elpepe@gmail.com',
      measures: [
        {
          date: '12/12/12',
          peso: 32,
          imc: 32,
          musculo: 62,
          grasa: 44,
          cintura: 44,
          cuello: 34,
          caderas: 124,
        },
        {
          date: '13/12/12',
          peso: 36,
          imc: 22,
          musculo: 12,
          grasa: 54,
          cintura: 34,
          cuello: 24,
          caderas: 114,
        },
      ],
    },

    {
      name: 'Josue',
      mail: 'josueMontero@gmail.com',
      measures: [
        {
          date: '12/12/12',
          peso: 32,
          imc: 32,
          musculo: 62,
          grasa: 44,
          cintura: 44,
          cuello: 34,
          caderas: 124,
        },
        {
          date: '13/12/12',
          peso: 36,
          imc: 22,
          musculo: 12,
          grasa: 54,
          cintura: 34,
          cuello: 24,
          caderas: 114,
        },
      ],
    },
  ];

  myclients: any[] = [
    {
      name: 'pepe',
      mail: 'elpepe@gmail.com',
      measures: [
        {
          date: '12/12/12',
          peso: 32,
          imc: 32,
          musculo: 62,
          grasa: 44,
          cintura: 44,
          cuello: 34,
          caderas: 124,
        },
        {
          date: '13/12/12',
          peso: 36,
          imc: 22,
          musculo: 12,
          grasa: 54,
          cintura: 34,
          cuello: 24,
          caderas: 114,
        },
      ],
    },
  ];
  searchResult: any[] = [];

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;

  constructor(
    public me: MatDialogRef<ClientSectionComponent>,
    private swal: SwalService,
    private com: ComService
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

  openClientMealHistory() {
    this.com.homeComp.openNutriPlan();
  }
  openClientMeasureHistory() {}
  autoComplete() {}

  searchUser() {
    //this.search

    this.searchResult = [];
    for (let i = 0; i < this.clients.length; i++) {
      console.log(this.clients[i]);

      if (
        this.clients[i].name.toLocaleLowerCase() ===
        this.search.toLocaleLowerCase()
      ) {
        this.searchResult.push(this.clients[i]);
        continue;
      }
      if (
        this.clients[i].name[0].toLocaleLowerCase() ===
        this.search[0].toLocaleLowerCase()
      ) {
        this.searchResult.push(this.clients[i]);
        continue;
      }
    }
    console.log(this.searchResult);
  }

  selectSearchClient(product: any) {
    this.myclients.push(product);
    this.searching = false;
  }
  removeClient(product: any) {
    this.myclients.splice(this.myclients.indexOf(product, 0), 1);
  }
}
