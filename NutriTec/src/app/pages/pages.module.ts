import { NgModule } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { ProductAddingComponent } from './menus/product-adding/product-adding.component';
import { RecipeAddingComponent } from './menus/recipe-adding/recipe-adding.component';
import { NutriPlanComponent } from './menus/nutri-plan/nutri-plan.component';
import { ClientSectionComponent } from './menus/client-section/client-section.component';
import { RecipeApprovingComponent } from './menus/recipe-approving/recipe-approving.component';
import { MeasuresComponent } from './menus/measures/measures.component';
import { ProductSearchComponent } from './menus/recipe-adding/product-search/product-search.component';
import { ProductApprovingComponent } from './menus/product-approving/product-approving.component';
import { BillManageComponent } from './menus/bill-manage/bill-manage.component';
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
    ProductApprovingComponent,
    BillManageComponent,
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    MatDialogModule,
    MatMenuModule,
    MatIconModule,
    MatTooltipModule,

    CommonModule,
    PagesRoutingModule,
  ],
})
export class PagesModule {}
