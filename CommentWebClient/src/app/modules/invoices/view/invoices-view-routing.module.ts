import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoicesViewComponent } from './invoices-view.component';

const routes: Routes = [
  { path: '', component: InvoicesViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoicesViewRoutingModule {
}
