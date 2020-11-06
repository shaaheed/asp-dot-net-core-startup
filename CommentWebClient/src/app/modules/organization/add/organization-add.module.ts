import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrganizationAddComponent } from './organization-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { OrganizationAddRoutingModule } from './organization-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerService } from 'src/services/customer.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    OrganizationAddComponent
  ],
  imports: [
    OrganizationAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    SharedModule,
    BoxLoaderModule
  ],
  exports: [OrganizationAddComponent],
  providers: [CustomerService]
})
export class OrganizationAddModule {

}
