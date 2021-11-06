import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductAddingComponent } from '../menus/product-adding/product-adding.component';
import { RecipeAddingComponent } from '../menus/recipe-adding/recipe-adding.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY' && !this.dialogIsOpen) this.swithUserType();
  }

  constructor(public dialog: MatDialog) {}
  user: boolean = true;
  admin: boolean = false;
  doctor: boolean = false;

  dialogIsOpen: boolean = false;

  ngOnInit(): void {
    this.openAddRecipe();
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

  swithUserType() {
    if (this.user) {
      this.user = false;
      this.admin = true;
      return;
    }
    if (this.admin) {
      this.admin = false;
      this.doctor = true;
      return;
    }
    if (this.doctor) {
      this.doctor = false;
      this.user = true;
      return;
    }
  }
}
