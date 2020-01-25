import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsAddComponent } from './products-add.component';

const routes: Routes = [
  { path: '', component: ProductsAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsAddRoutingModule { }
