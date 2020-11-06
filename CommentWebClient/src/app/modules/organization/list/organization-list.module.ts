import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzToolTipModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerService } from 'src/services/customer.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { OrganizationListComponent } from './organization-list.component';
import { OrganizationListRoutingModule } from './organization-list-routing.module';

@NgModule({
  declarations: [
    OrganizationListComponent
  ],
  imports: [
    CommonModule,
    OrganizationListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    SharedModule,
    NzToolTipModule,
    BoxLoaderModule
  ],
  exports: [OrganizationListComponent],
  providers: [CustomerService]
})
export class OrganizationListModule { }
