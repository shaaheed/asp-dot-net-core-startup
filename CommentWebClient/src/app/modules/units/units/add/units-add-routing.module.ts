import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnitsAddComponent } from './units-add.component';

const routes: Routes = [
  { path: '', component: UnitsAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitsAddRoutingModule { }
