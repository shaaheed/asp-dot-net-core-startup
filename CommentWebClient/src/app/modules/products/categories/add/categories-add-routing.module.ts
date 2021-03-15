import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoriesAddComponent } from './categories-add.component';

const routes: Routes = [
  { path: '', component: CategoriesAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesAddRoutingModule { }
