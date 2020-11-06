import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrganizationListComponent } from './organization-list.component';

const routes: Routes = [
  { path: '', component: OrganizationListComponent },
  { path: 'create', loadChildren: () => import('../add/organization-add.module').then(x => x.OrganizationAddModule) },
  { path: ':id/edit', loadChildren: () => import('../add/organization-add.module').then(x => x.OrganizationAddModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationListRoutingModule {
}
