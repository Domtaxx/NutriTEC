import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { UserService } from 'src/app/services/userService';
import { DatePipe } from '@angular/common';
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

  today: boolean = true;
  history: boolean = false;
  plan: boolean = false;

  //todayVars
  tFoods: any = {
    date: '',
    meals: [
      {
        name: 'Desayuno',
        foods: [],
      },
      {
        name: 'Merienda 1',
        foods: [],
      },
      {
        name: 'Almuerzo',
        foods: [],
      },
      {
        name: 'Merienda 2',
        foods: [],
      },
      {
        name: 'Cena',
        foods: [],
      },
    ],
    feedBack: '',
  };
  currentTfood: any; //comida del dia

  foodHistory: any = []; //containsTfoodsObjects
  foodPlan: any;

  selectedmenus: any[] = [];
  searchResult: any[] = [];

  search: string = '';
  searching: boolean = false;
  finishing: boolean = false;

  constructor(
    public me: MatDialogRef<NutriPlanComponent>,
    private swal: SwalService,
    public uServ: UserService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public backend: BackendService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    if (this.uServ.doctor) {
      this.today = false;
      this.history = true;
    }
    this.getReports();

    this.getPlan();
  }

  createTfoodReport(fecha: any, feedBack: string, foods: any[]) {
    return {
      fecha: fecha,
      feedBack: feedBack,
      foods: foods,
    };
  }

  updateNutriPlan() {
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
      'Plan actualizado!',
      'El plan se ha actualizado y el cliente podrá verlo'
    );
    this.me.close();
  }
  commentReport(report: any) {
    const data = {
      identification: this.data.user.correo,
      date: this.datePipe.transform(report.fecha, 'yyyy-MM-dd'),
      description: report.feedBack,
    };

    this.backend
      .post_request2(
        'https://nutritecmongoapi.azurewebsites.net/api/notes',
        data
      )
      .subscribe((result) => {
        this.swal.showSuccess('exito', 'modificación realizada');
      });
  }
  /**
   * Report a daily report to db
   */
  submitDailyReport() {
    const currentDate = new Date();

    this.tFoods.meals.forEach((tiempoDeComida: any) => {
      tiempoDeComida.foods.forEach((recetaConsumida: any) => {
        let user;
        if (!this.data.user)
          user = JSON.parse(localStorage.getItem('user') as string)[0];
        else user = this.data.user;

        const data = {
          nombreReceta: recetaConsumida.nombre,
          correoCliente: user.correo,
          correoCreador: recetaConsumida.correoCreador,
          fecha: currentDate,
          tiempo: tiempoDeComida.name,
        };

        this.backend
          .post_request('Reportes/Recetas', data)

          .subscribe((response) => {});
      });
    });
  }
  openSearchBox(tfood: any) {
    this.searching = true;
    this.currentTfood = tfood;
  }

  searchProduct() {
    const data = {
      creator: '',
      name: this.search,
    };
    this.searchResult = [];
    this.backend.get_request('Receta/Busqueda', data).subscribe((result) => {
      this.searchResult = result;
    });
  }

  selectSearchProduct(menu: any) {
    this.currentTfood.foods.push(menu);
    this.searching = false;
  }
  removeProduct(menu: any, tfood: any) {
    tfood.foods.splice(this.selectedmenus.indexOf(menu, 0), 1);
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
  /**
   * Complete tFood Forms
   * @param tfood
   * @param maxmenus
   */
  autocompleteTfood(tfood: any, maxmenus: number) {
    tfood.date = new Date();

    this.backend.get_request('Receta/Todos', null).subscribe((result) => {
      this.selectedmenus = result;
      tfood.meals.forEach((meal: { foods: any[] }) => {
        meal.foods = this.selectedmenus.slice(0, maxmenus);
      });
    });
  }

  /**
   * Autocomplete forms
   */
  autoComplete() {
    const maxmenus = 1;
    const maxTfoods = 3;

    this.autocompleteTfood(this.tFoods, maxmenus);

    for (let i = 0; i < maxTfoods; i++) {
      let newTfood = {
        date: '',
        meals: [
          {
            name: 'Desayuno',
            foods: [],
          },
          {
            name: 'Merienda 1',
            foods: [],
          },
          {
            name: 'Almuerzo',
            foods: [],
          },
          {
            name: 'Merienda 2',
            foods: [],
          },
          {
            name: 'Cena',
            foods: [],
          },
        ],
        feedBack: 'Muy bien, sigue así',
      };

      this.autocompleteTfood(newTfood, maxmenus);
      this.foodHistory.push(newTfood);
    }
  }
  /**
   * Gets user consumption plan from db
   */
  getPlan() {
    ///OBTENEMOS EL PLAN DE ALIMENTACION

    let user;
    if (!this.data.user)
      user = JSON.parse(localStorage.getItem('user') as string)[0];
    else user = this.data.user;

    this.backend
      .get_request('Nutricionista/Clientes/plan', {
        Correo_cliente: user.correo,
      })
      .subscribe((plan) => {
        let foodPlan = {
          meals: [
            {
              name: 'Desayuno',
              foods: [],
            },
            {
              name: 'Merienda 1',
              foods: [],
            },
            {
              name: 'Almuerzo',
              foods: [],
            },
            {
              name: 'Merienda 2',
              foods: [],
            },
            {
              name: 'Cena',
              foods: [],
            },
          ],
          feedBack: 'Muy bien, sigue así',
        };

        plan.forEach((menu: any) => {
          foodPlan.meals.forEach((meal: any) => {
            if (meal.name === menu.nombre) {
              menu.menuProductos.forEach((product: any) => {
                const x = {
                  name: product.codigoBarrasNavigation.descripcion,
                  info: product.codigoBarras,
                };
                meal.foods.push(x);
              });

              menu.menuReceta.forEach((recipe: any) => {
                const x = {
                  name: recipe.nombreReceta,
                  info: recipe.correoCreador,
                };
                meal.foods.push(x);
              });
              console.log(foodPlan);
              this.foodPlan = foodPlan;
            }
          });
        });
      });
  }
  /**
   * Obtiene el historial de consumo
   */
  getReports() {
    let user: any;
    if (!this.data.user)
      user = JSON.parse(localStorage.getItem('user') as string)[0];
    else user = this.data.user;
    this.backend
      .get_request('Reportes/Recetas', { Correo_cliente: user.correo })
      .subscribe((result) => {
        const reportsBydate: any[] = [];
        const reportsBydateAndTime: any[] = [];

        result.forEach((foodReport: any) => {
          let objectWithSameDate = false;
          reportsBydate.forEach((reportByDate) => {
            if (reportByDate.fecha === foodReport.fecha) {
              reportByDate.reports.push(foodReport);
              objectWithSameDate = true;
            }
          });

          if (!objectWithSameDate) {
            const newReportByDate = {
              fecha: foodReport.fecha,
              reports: [foodReport],
            };
            reportsBydate.push(newReportByDate);
          }
        });

        //A este punto, se tiene los reportes ordenados por fecha, pero las comidas consumidas no están agrupadas
        reportsBydate.forEach((dateReport: any) => {
          //
          //
          let meals: any[] = [
            {
              name: 'Desayuno',
              foods: [],
            },
            {
              name: 'Merienda 1',
              foods: [],
            },
            {
              name: 'Almuerzo',
              foods: [],
            },
            {
              name: 'Merienda 2',
              foods: [],
            },
            {
              name: 'Cena',
              foods: [],
            },
          ];
          dateReport.reports.forEach((reporteDeConsumo: any) => {
            //
            meals.forEach((value) => {
              if (reporteDeConsumo.tiempo === value.name)
                value.foods.push({
                  nombre: reporteDeConsumo.nombre,
                  correoCrador: reporteDeConsumo.correoCreador,
                });
            });
          });

          const dateString: string = (dateReport.fecha as Date).toString();
          const data = {
            id: user.correo,
            date: dateString.substring(dateString.indexOf('T'), -1),
          };

          this.backend
            .get_requestTotal(
              'https://nutritecmongoapi.azurewebsites.net/api/notes',
              data
            )
            .subscribe((result) => {
              reportsBydateAndTime.push(
                this.createTfoodReport(
                  dateReport.fecha,
                  result.description,
                  meals
                )
              );
            });
        });
        console.log('////////////////');
        console.log(reportsBydateAndTime);

        this.foodHistory = reportsBydateAndTime;
      });
  }
}

//Objects contain by this array, contains the next Structure objects
/*
        reportsBydate=[
                        {
                        fecha:dateTime,
                        reports:[ 
                                  {
                                        "correoCliente": "mangel12412@gmail.com",
                                        "nombre": "Galletas Exquisitas",
                                        "correoCreador": "mangel12412@gmail.com",
                                        "fecha": "2021-11-15T00:00:00",
                                        "tiempo": "almuerzo",
                                        "calcio": 15.5,
                                        "hierro": 10,
                                        "energia": 500,
                                        "sodio": 12.5,
                                        "carbohidratos": 354,
                                        "proteina": 2,
                                        "vitaminas": 20,
                                        "tamano": 1024
                                  },
                                ]
                      }
                    ]

      BUT WHE WANT THISS

       reportsBydateAndTime=   [
                                  {
                                    fecha:dateTime,
                                    feedBack:''
                                    foods: [
                                      {
                                        tiempo: 'desayuno',
                                        foods: [{
                                          nombre: "Galletas Exquisitas",
                                          correoCreador: "mangel12412@gmail.com",
                                        }],
                                      },
                                      {
                                        tiempo: 'merienda ',
                                        foods: [],
                                      },
                                      {
                                        tiempo: 'almuerzo',
                                        foods: [],
                                      },
                                      {
                                        tiempo: 'merienda2 ',
                                        foods: [],
                                      },
                                      {
                                        tiempo: 'cena',
                                        foods: [],
                                      },
                                    ],
                                  }
                                ]
      */
