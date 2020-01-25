import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoicesAddComponent } from './invoices-add.component';

const routes: Routes = [
  { path: '', component: InvoicesAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoicesAddRoutingModule { }
