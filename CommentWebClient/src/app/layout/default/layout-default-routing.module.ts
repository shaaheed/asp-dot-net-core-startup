import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutDefaultComponent } from './layout-default.component';
import { AuthGuard } from 'src/app/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LayoutDefaultComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: 'permissions', loadChildren: () => import('../../permissions/permissions.module').then(m => m.PermissionsModule) },
      { path: 'organizations', loadChildren: () => import('../../modules/organization/list/organization-list.module').then(m => m.OrganizationListModule) },
      { path: 'users', loadChildren: () => import('../../components/users/users.module').then(m => m.UsersModule) },
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
