import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TaxesAddComponent } from './taxes-add.component';

const routes: Routes = [
  { path: '', component: TaxesAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaxesAddRoutingModule { }
