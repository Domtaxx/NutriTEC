import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-nutri-plan',
  templateUrl: './nutri-plan.component.html',
  styleUrls: ['./nutri-plan.component.css'],
})
export class NutriPlanComponent implements OnInit {
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

  today: boolean = true;
  history: boolean = false;
  plan: boolean = false;

  //todayVars
  tFoods: any = {
    date: '',
    meals: [
      {
        name: 'desayuno',
        foods: [],
      },
      {
        name: 'merienda mañana',
        foods: [],
      },
      {
        name: 'almuerzo',
        foods: [],
      },
      {
        name: 'merienda tarde',
        foods: [],
      },
      {
        name: 'cena',
        foods: [],
      },
    ],
    feedBack: '',
  };
  currentTfood: any; //comida del dia

  foodHistory: any = []; //containsTfoodsObjects
  foodPlan: any;

  selectedProducts: any[] = [];
  searchResult: any[] = [];

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;

  constructor(
    public me: MatDialogRef<NutriPlanComponent>,
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

  openSearchBox(tfood: any) {
    this.searching = true;
    this.currentTfood = tfood;
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
    this.currentTfood.foods.push(product);
    this.searching = false;
  }
  removeProduct(product: any, tfood: any) {
    console.log(product);
    console.log(tfood);
    tfood.foods.splice(this.selectedProducts.indexOf(product, 0), 1);
  }

  openToday() {
    this.today = true;
    this.history = false;
    this.plan = false;
  }
  openHistory() {
    this.today = false;
    this.history = true;
    this.plan = false;
  }
  openPlan() {
    this.today = false;
    this.history = false;
    this.plan = true;
  }

  autocompleteTfood(tfood: any, maxProducts: number) {
    tfood.date = new Date();
    this.selectedProducts = this.products.slice();
    tfood.meals.forEach((meal: { foods: any[] }) => {
      meal.foods = this.products.slice(0, maxProducts);
    });
  }
  autoComplete() {
    const maxProducts = 3;
    const maxTfoods = 3;

    this.autocompleteTfood(this.tFoods, maxProducts);

    for (let i = 0; i < maxTfoods; i++) {
      let newTfood = {
        date: '',
        meals: [
          {
            name: 'desayuno',
            foods: [],
          },
          {
            name: 'merienda mañana',
            foods: [],
          },
          {
            name: 'almuerzo',
            foods: [],
          },
          {
            name: 'merienda tarde',
            foods: [],
          },
          {
            name: 'cena',
            foods: [],
          },
        ],
        feedBack: 'Muy bien, sigue así',
      };

      this.autocompleteTfood(newTfood, maxProducts);
      this.foodHistory.push(newTfood);
    }

    //Para el plan
    let newTfood = {
      date: '',
      meals: [
        {
          name: 'desayuno',
          foods: [],
        },
        {
          name: 'merienda mañana',
          foods: [],
        },
        {
          name: 'almuerzo',
          foods: [],
        },
        {
          name: 'merienda tarde',
          foods: [],
        },
        {
          name: 'cena',
          foods: [],
        },
      ],
      feedBack: 'Muy bien, sigue así',
    };
    this.autocompleteTfood(newTfood, maxProducts);
    this.foodPlan = newTfood;
  }
}
