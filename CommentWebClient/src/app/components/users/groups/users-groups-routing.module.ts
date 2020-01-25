import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersGroupsComponent } from './users-groups.component';

const routes: Routes = [
  { path: '', component: UsersGroupsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersGroupsRoutingModule { }
