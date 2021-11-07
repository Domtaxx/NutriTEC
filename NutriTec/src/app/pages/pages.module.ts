import { NgModule } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { ProductAddingComponent } from './menus/product-adding/product-adding.component';
import { RecipeAddingComponent } from './menus/recipe-adding/recipe-adding.component';
import { NutriPlanComponent } from './nutri-plan/nutri-plan.component';
import { ClientSectionComponent } from './client-section/client-section.component';
import { RecipeApprovingComponent } from './recipe-approving/recipe-approving.component';
import { MeasuresComponent } from './menus/measures/measures.component';
import { ProductSearchComponent } from './menus/recipe-adding/product-search/product-search.component';
@NgModule({
  declarations: [
    PagesComponent,
    HomeComponent,
    ProductAddingComponent,
    RecipeAddingComponent,
    NutriPlanComponent,
    ClientSectionComponent,
    RecipeApprovingComponent,
    MeasuresComponent,
    ProductSearchComponent,
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    MatDialogModule,
    MatMenuModule,
    MatIconModule,

    CommonModule,
    PagesRoutingModule,
  ],
})
export class PagesModule {}
