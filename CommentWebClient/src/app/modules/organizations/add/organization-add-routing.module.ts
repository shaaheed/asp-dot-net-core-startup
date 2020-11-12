import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrganizationAddComponent } from './organization-add.component';

const routes: Routes = [
  { path: '', component: OrganizationAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationAddRoutingModule { }
