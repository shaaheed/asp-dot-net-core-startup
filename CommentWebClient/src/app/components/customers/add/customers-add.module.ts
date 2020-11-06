import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomersAddComponent } from './customers-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { CustomersAddRoutingModule } from './customers-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerService } from 'src/services/customer.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    CustomersAddComponent
  ],
  imports: [
    CustomersAddRoutingModule,
    CommonModule,
    NzTableModule,
    NzButtonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    SharedModule,
    BoxLoaderModule
  ],
  exports: [CustomersAddComponent],
  providers: [CustomerService]
})
export class CustomersAddModule {

}
