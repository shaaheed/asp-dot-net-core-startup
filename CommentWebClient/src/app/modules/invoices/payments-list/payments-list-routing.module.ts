import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoicePaymentListComponent } from './payments-list.component';

const routes: Routes = [
  { path: '', component: InvoicePaymentListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoicePaymentListRoutingModule {
}
