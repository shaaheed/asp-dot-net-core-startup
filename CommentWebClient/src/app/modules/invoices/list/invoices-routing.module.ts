import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoicesComponent } from './invoices.component';

const routes: Routes = [
  { path: '', component: InvoicesComponent },
  { path: 'create', loadChildren: () => import('../add/invoices-add.module').then(x => x.InvoicesAddModule) },
  { path: ':id/edit', loadChildren: () => import('../add/invoices-add.module').then(x => x.InvoicesAddModule) },
  { path: ':id', loadChildren: () => import('../home/invoice-home.module').then(x => x.InvoiceHomeModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoicesRoutingModule {
}
