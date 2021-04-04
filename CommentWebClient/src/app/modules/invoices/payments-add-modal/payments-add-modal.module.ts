import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentsAddModalComponent } from './payments-add-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { PaymentService } from '../services/payment.service';
import { DatePickerModule } from 'src/app/shared/date/date.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { AppFormModule } from 'src/app/shared/form/form.module';
import { TextModule } from 'src/app/shared/text/text.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

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
    NzMenuModule,
    NzDropDownModule,
    SharedModule,
    NzSelectModule,
    NzModalModule,
    NzDatePickerModule,
    NzButtonModule,
    DatePickerModule,
    InputModule,
    AppFormModule,
    TextModule,
    SelectControlModule
  ],
  exports: [PaymentsAddModalComponent],
  providers: [InvoiceService, PaymentService]
})
export class PaymentsAddModalModule {

}
