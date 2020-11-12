import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutDefaultComponent } from './layout-default.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ORGANIZATION_CONFIG } from 'src/app/modules/organizations/organization.config';
import { USER_MODULE_CONFIG } from 'src/app/modules/users/user.module.config';

const routes: Routes = [
  {
    path: '',
    component: LayoutDefaultComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: 'permissions', loadChildren: () => import('../../permissions/permissions.module').then(m => m.PermissionsModule) },
      ...ORGANIZATION_CONFIG.ROUTES,
      ...USER_MODULE_CONFIG.ROUTES,
      { path: 'products', loadChildren: () => import('../../components/products/products.module').then(m => m.ProductsModule) },
      { path: 'customers', loadChildren: () => import('../../components/customers/customers.module').then(m => m.CustomersModule) },
      { path: 'vendors', loadChildren: () => import('../../modules/vendors/list/vendor-list.module').then(m => m.VendorListModule) },
      { path: 'invoices', loadChildren: () => import('../../modules/invoices/list/invoices.module').then(m => m.InvoicesModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutDefaultRoutingModule {

  menuCollapsed = false

}
