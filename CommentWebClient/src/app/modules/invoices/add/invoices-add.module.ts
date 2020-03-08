import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDropDownModule, NzMenuModule, NzSelectModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InvoicesAddComponent } from './invoices-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { InvoicesAddRoutingModule } from './invoices-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    InvoicesAddComponent
  ],
  imports: [
    InvoicesAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    NzMenuModule,
    NzDropDownModule,
    SharedModule,
    NzSelectModule,
    BoxLoaderModule
  ],
  exports: [InvoicesAddComponent],
  providers: [InvoiceService]
})
export class InvoicesAddModule {

}
