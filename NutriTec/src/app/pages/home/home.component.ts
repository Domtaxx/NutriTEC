import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MeasuresComponent } from '../menus/measures/measures.component';
import { ProductAddingComponent } from '../menus/product-adding/product-adding.component';
import { RecipeAddingComponent } from '../menus/recipe-adding/recipe-adding.component';
import { NutriPlanComponent } from '../menus/nutri-plan/nutri-plan.component';
import { ClientSectionComponent } from '../menus/client-section/client-section.component';
import { UserService } from 'src/app/services/userService';
import { ComService } from 'src/app/services/comService';
import { RecipeApprovingComponent } from '../menus/recipe-approving/recipe-approving.component';
import { ProductApprovingComponent } from '../menus/product-approving/product-approving.component';
import { BillManageComponent } from '../menus/bill-manage/bill-manage.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY' && !this.dialogIsOpen) this.uServ.swithUserType();
  }

  constructor(
    public dialog: MatDialog,
    public uServ: UserService,
    public com: ComService
  ) {}

  dialogIsOpen: boolean = false;

  ngOnInit(): void {
    this.com.homeComp = this;
  }
  /**
   * def opens Add Product dialog
   */
  openAddProduct() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(ProductAddingComponent, {
      width: '60%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }

  /**
   * def opens Add Recipe dialog
   */
  openAddRecipe() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(RecipeAddingComponent, {
      width: '60%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }
  /**
   * def opens Nutriplan dialog
   */
  openNutriPlan() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(NutriPlanComponent, {
      width: '80%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }

  /**
   * def opens measures dialog
   */
  openMeasures() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(MeasuresComponent, {
      width: '40%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }

  /**
   * def opens client management dialog
   */
  openClientSection() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(ClientSectionComponent, {
      width: '40%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }

  /**
   * def opens Add Recipe dialog
   */
  openAproveRecipe() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(RecipeApprovingComponent, {
      width: '60%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }
  /**
   * def opens Aprove Prouduct dialog
   */
  openAproveProduct() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(ProductApprovingComponent, {
      width: '60%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }

  openBillManage() {
    this.dialogIsOpen = true;
    let dialogRef = this.dialog.open(BillManageComponent, {
      width: '60%',
      data: {},
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.dialogIsOpen = false;
    });
  }
  /**
   * ONLY FOR DEVS, SWITCH USER TYPE
   */
}
