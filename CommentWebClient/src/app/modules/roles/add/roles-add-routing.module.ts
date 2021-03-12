import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RolesAddComponent } from './roles-add.component';

const routes: Routes = [
  { path: '', component: RolesAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RolesAddRoutingModule { }
