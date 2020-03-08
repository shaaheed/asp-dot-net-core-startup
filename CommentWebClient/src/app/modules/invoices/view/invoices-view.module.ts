import { NgModule } from '@angular/core';

import { InvoicesViewComponent } from './invoices-view.component';
import { InvoicesViewRoutingModule } from './invoices-view-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzToolTipModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { PaymentsAddModalModule } from '../payments-add-modal/payments-add-modal.module';

@NgModule({
  declarations: [
    InvoicesViewComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    NgZorroAntdModule,
    SharedModule,
    NzToolTipModule,
    InvoicesViewRoutingModule,
    PaymentsAddModalModule,
    BoxLoaderModule
  ],
  exports: [InvoicesViewComponent],
  providers: [InvoiceService]
})
export class InvoicesViewModule { }
