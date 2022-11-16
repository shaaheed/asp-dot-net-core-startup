import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutDefaultComponent } from './layout-default.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ORGANIZATION_CONFIG } from 'src/app/modules/organizations/organization.config';
import { USER_MODULE_CONFIG } from 'src/app/modules/users/user.module.config';
import { ROLE_MODULE_CONFIG } from 'src/app/modules/roles/role.module.config';
import { PRODUCT_MODULE_CONFIG } from 'src/app/modules/products/products/product.config';
// import { UNIT_MODULE_CONFIG } from 'src/app/modules/units/unit.module.config';
import { UNIT_TYPE_MODULE_CONFIG } from 'src/app/modules/units/type.module.config';
import { CATEGORY_MODULE_CONFIG } from 'src/app/modules/products/category.module.config';
import { TAX_MODULE_CONFIG } from 'src/app/modules/taxes/tax.module.config';
import { CUSTOMER_CONFIG } from 'src/app/modules/customers/customer.config';
import { SUPPLIER_CONFIG } from 'src/app/modules/suppliers/supplier.config';
import { INVOICE_CONFIG } from 'src/app/modules/invoices/invoice.config';
import { BILL_CONFIG } from 'src/app/modules/bills/bill.config';
import { INVENTORY_ADJUSTMENT_MODULE_CONFIG } from 'src/app/modules/inventories/adjustments/products/adjustment.module.config';
import { PRICE_LEVEL_MODULE_CONFIG } from 'src/app/modules/price-levels/price-levels.module.config';
import { TERM_MODULE_CONFIG } from 'src/app/modules/terms/terms.module.config';

const routes: Routes = [
  {
    path: '',
    component: LayoutDefaultComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: 'permissions', loadChildren: () => import('../../permissions/permissions.module').then(m => m.PermissionsModule) },
      ...ORGANIZATION_CONFIG.ROUTES,
      ...USER_MODULE_CONFIG.ROUTES,
      ...ROLE_MODULE_CONFIG.ROUTES,
      ...PRODUCT_MODULE_CONFIG.ROUTES,
      ...CATEGORY_MODULE_CONFIG.ROUTES,
      // ...UNIT_MODULE_CONFIG.ROUTES,
      ...UNIT_TYPE_MODULE_CONFIG.ROUTES,
      ...TAX_MODULE_CONFIG.ROUTES,
      ...CUSTOMER_CONFIG.ROUTES,
      ...SUPPLIER_CONFIG.ROUTES,
      ...INVOICE_CONFIG.ROUTES,
      ...BILL_CONFIG.ROUTES,
      ...INVENTORY_ADJUSTMENT_MODULE_CONFIG.ROUTES,
      // { path: 'invoices', loadChildren: () => import('../../modules/invoices/list/invoices.module').then(m => m.InvoicesModule) }

      ...PRICE_LEVEL_MODULE_CONFIG.ROUTES,
      ...TERM_MODULE_CONFIG.ROUTES
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
