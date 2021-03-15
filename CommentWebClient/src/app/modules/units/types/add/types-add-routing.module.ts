import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnitTypesAddComponent } from './types-add.component';

const routes: Routes = [
  { path: '', component: UnitTypesAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitTypesAddRoutingModule { }
