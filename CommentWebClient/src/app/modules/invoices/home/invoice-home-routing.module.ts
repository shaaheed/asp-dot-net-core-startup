import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoiceHomeComponent } from './invoice-home.component';

const routes: Routes = [
  {
    path: '',
    component: InvoiceHomeComponent,
    children: [
      { path: 'payments', loadChildren: () => import('../payments-list/payments-list.module').then(x => x.InvoicePaymentListModule) },
      { path: 'view', loadChildren: () => import('../view/invoices-view.module').then(x => x.InvoicesViewModule) }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceHomeRoutingModule {
}
