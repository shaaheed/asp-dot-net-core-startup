import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermissionsComponent } from './permissions.component';

const routes: Routes = [
  {
    path: '',
    component: PermissionsComponent,
    children: [
      { path: 'resources', loadChildren: () => import('./resources/resources.module').then(x => x.ResourcesModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PermissionsRoutingModule { }
