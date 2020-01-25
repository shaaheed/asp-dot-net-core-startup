import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router, Route } from '@angular/router';
import { ProductsComponent } from './products.component';

const routes: Routes = [
  { path: '', component: ProductsComponent },
  { path: 'create', loadChildren: () => import('./add/products-add.module').then(x => x.ProductsAddModule) },
  { path: ':id/edit', loadChildren: () => import('./add/products-add.module').then(x => x.ProductsAddModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule {
}
