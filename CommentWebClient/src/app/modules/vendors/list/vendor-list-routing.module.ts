import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendorListComponent } from './vendor-list.component';

const routes: Routes = [
  { path: '', component: VendorListComponent },
  { path: 'create', loadChildren: () => import('../add/vendor-add.module').then(x => x.VendorAddModule) },
  { path: ':id/edit', loadChildren: () => import('../add/vendor-add.module').then(x => x.VendorAddModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorListRoutingModule {
}
