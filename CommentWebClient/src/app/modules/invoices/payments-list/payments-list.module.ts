import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzToolTipModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { PaymentsAddModalModule } from '../payments-add-modal/payments-add-modal.module';
import { InvoicePaymentListComponent } from './payments-list.component';
import { InvoicePaymentListRoutingModule } from './payments-list-routing.module';

@NgModule({
  declarations: [
    InvoicePaymentListComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    NgZorroAntdModule,
    SharedModule,
    NzToolTipModule,
    InvoicePaymentListRoutingModule,
    PaymentsAddModalModule,
    BoxLoaderModule,
  ],
  exports: [InvoicePaymentListComponent],
  providers: [InvoiceService]
})
export class InvoicePaymentListModule { }
