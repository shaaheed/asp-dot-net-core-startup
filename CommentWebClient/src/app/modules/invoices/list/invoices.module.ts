import { NgModule } from '@angular/core';

import { InvoicesComponent } from './invoices.component';
import { InvoicesRoutingModule } from './invoices-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzToolTipModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    InvoicesComponent
  ],
  imports: [
    CommonModule,
    InvoicesRoutingModule,
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
  exports: [InvoicesComponent],
  providers: [InvoiceService]
})
export class InvoicesModule { }
