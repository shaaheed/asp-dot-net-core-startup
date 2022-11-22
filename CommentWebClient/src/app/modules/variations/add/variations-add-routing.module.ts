import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VariationsAddComponent } from './variations-add.component';

const routes: Routes = [
  { path: '', component: VariationsAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VariationsAddRoutingModule { }
