import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomersAddComponent } from './customers-add.component';

const routes: Routes = [
  { path: '', component: CustomersAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersAddRoutingModule { }
