import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomersAddComponent } from './customers-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { CustomersAddRoutingModule } from './customers-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CustomerService } from 'src/services/customer.service';

@NgModule({
  declarations: [
    CustomersAddComponent
  ],
  imports: [
    CustomersAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    SharedModule
  ],
  exports: [CustomersAddComponent],
  providers: [CustomerService]
})
export class CustomersAddModule {

}
