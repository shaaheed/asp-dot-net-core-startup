import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourcesGroupsComponent } from './resources-groups.component';

const routes: Routes = [
  { path: '', component: ResourcesGroupsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourcesGroupsRoutingModule { }
