import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { ProductAddingComponent } from './product-adding/product-adding.component';
import { RecipeAddingComponent } from './recipe-adding/recipe-adding.component';
import { NutriPlanComponent } from './nutri-plan/nutri-plan.component';
import { ClientSectionComponent } from './client-section/client-section.component';
import { RecipeApprovingComponent } from './recipe-approving/recipe-approving.component';
import { MeasuresComponent } from './measures/measures.component';


@NgModule({
  declarations: [PagesComponent, HomeComponent, ProductAddingComponent, RecipeAddingComponent, NutriPlanComponent, ClientSectionComponent, RecipeApprovingComponent, MeasuresComponent],
  imports: [
    CommonModule,
    PagesRoutingModule
  ]
})
export class PagesModule { }
