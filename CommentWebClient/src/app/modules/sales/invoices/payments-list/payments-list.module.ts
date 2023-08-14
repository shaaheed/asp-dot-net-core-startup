import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
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
    SharedModule,
    NzToolTipModule,
    InvoicePaymentListRoutingModule,
    PaymentsAddModalModule,
    BoxLoaderModule,
    NzTagModule,
    NzDropDownModule
  ],
  exports: [InvoicePaymentListComponent],
  providers: [InvoiceService]
})
export class InvoicePaymentListModule { }
