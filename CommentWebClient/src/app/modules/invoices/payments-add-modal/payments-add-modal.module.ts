import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDropDownModule, NzMenuModule, NzSelectModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentsAddModalComponent } from './payments-add-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { PaymentService } from '../services/payment.service';

@NgModule({
  declarations: [
    PaymentsAddModalComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzMenuModule,
    NzDropDownModule,
    SharedModule,
    NzSelectModule,
  ],
  exports: [PaymentsAddModalComponent],
  providers: [InvoiceService, PaymentService]
})
export class PaymentsAddModalModule {

}
