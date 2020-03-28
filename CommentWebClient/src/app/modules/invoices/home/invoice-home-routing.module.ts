import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoiceHomeComponent } from './invoice-home.component';
import { InvoiceIdResolver } from './invoice-id.resolver';

const routes: Routes = [
  {
    path: '',
    component: InvoiceHomeComponent,
    children: [
      {
        path: 'payments',
        loadChildren: () => import('../payments-list/payments-list.module').then(x => x.InvoicePaymentListModule),
        resolve: {
          invoiceId: InvoiceIdResolver
        }
      },
      {
        path: 'view',
        loadChildren: () => import('../view/invoices-view.module').then(x => x.InvoicesViewModule),
        resolve: {
          invoiceId: InvoiceIdResolver
        }
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceHomeRoutingModule {
}
