import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourcesComponent } from './resources.component';

const routes: Routes = [
  { path: '', component: ResourcesComponent },
  { path: 'groups', loadChildren: () => import('./group/resources-groups.module').then(x => x.ResourcesGroupsModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourcesRoutingModule { }
