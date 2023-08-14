import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutDefaultComponent } from './layout-default.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ORGANIZATION_CONFIG } from 'src/app/modules/organizations/organization.config';
import { USER_MODULE_CONFIG } from 'src/app/modules/users/user.module.config';
import { ROLE_MODULE_CONFIG } from 'src/app/modules/roles/role.module.config';
import { UNIT_MODULE_CONFIG } from 'src/app/modules/units/unit.module.config';
import { TAX_MODULE_CONFIG } from 'src/app/modules/sales/taxes/tax.module.config';
import { SUPPLIER_CONFIG } from 'src/app/modules/sales/suppliers/supplier.config';
import { PRICE_LEVEL_MODULE_CONFIG } from 'src/app/modules/sales/price-levels/price-levels.module.config';
import { TERM_MODULE_CONFIG } from 'src/app/modules/sales/terms/terms.module.config';
import { VARIATION_MODULE_CONFIG } from 'src/app/modules/variations/variation.module.config';
import { ORGANIZATION_CURRENCY_CONFIG } from 'src/app/modules/organizations/currencies/organization-currency.config';
import { PRODUCT_MODULE_CONFIG } from 'src/app/modules/sales/products/products/product.config';
import { PRODUCT_CATEGORY_MODULE_CONFIG } from 'src/app/modules/sales/products/category.module.config';
import { CUSTOMER_CONFIG } from 'src/app/modules/sales/customers/customer.config';
import { INVOICE_CONFIG } from 'src/app/modules/sales/invoices/invoice.config';
import { BILL_CONFIG } from 'src/app/modules/sales/bills/bill.config';
import { INVENTORY_ADJUSTMENT_MODULE_CONFIG } from 'src/app/modules/sales/inventories/adjustments/products/adjustment.module.config';

const routes: Routes = [
  {
    path: '',
    component: LayoutDefaultComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: 'permissions', loadChildren: () => import('../../permissions/permissions.module').then(m => m.PermissionsModule) },
      ...ORGANIZATION_CONFIG.ROUTES,
      ...ORGANIZATION_CURRENCY_CONFIG.ROUTES,
      ...USER_MODULE_CONFIG.ROUTES,
      ...ROLE_MODULE_CONFIG.ROUTES,

      // Sales
      ...PRODUCT_MODULE_CONFIG.ROUTES,
      ...PRODUCT_CATEGORY_MODULE_CONFIG.ROUTES,
      ...UNIT_MODULE_CONFIG.ROUTES,
      ...TAX_MODULE_CONFIG.ROUTES,
      ...CUSTOMER_CONFIG.ROUTES,
      ...SUPPLIER_CONFIG.ROUTES,
      ...INVOICE_CONFIG.ROUTES,
      ...BILL_CONFIG.ROUTES,
      ...INVENTORY_ADJUSTMENT_MODULE_CONFIG.ROUTES,
      ...PRICE_LEVEL_MODULE_CONFIG.ROUTES,
      ...TERM_MODULE_CONFIG.ROUTES,
      ...VARIATION_MODULE_CONFIG.ROUTES
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
