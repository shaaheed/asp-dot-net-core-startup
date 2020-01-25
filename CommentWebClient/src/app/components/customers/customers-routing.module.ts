import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router, Route } from '@angular/router';
import { CustomersComponent } from './customers.component';

const routes: Routes = [
  { path: '', component: CustomersComponent },
  { path: 'create', loadChildren: () => import('./add/customers-add.module').then(x => x.CustomersAddModule) },
  { path: ':id/edit', loadChildren: () => import('./add/customers-add.module').then(x => x.CustomersAddModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule {
}
