import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users.component';

const routes: Routes = [
  { path: '', component: UsersComponent },
  { path: 'groups', loadChildren: () => import('./groups/users-groups.module').then(x => x.UsersGroupsModule) },
  { path: ':id', loadChildren: () => import('./add/users-add.module').then(x => x.UsersAddModule) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
