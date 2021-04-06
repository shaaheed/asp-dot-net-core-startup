import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentsAddModalComponent } from './payments-add-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';
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
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SharedModule,
    NzModalModule,
    NzButtonModule,
    DatePickerModule,
    InputModule,
    AppFormModule,
    TextModule,
    SelectControlModule
  ],
  exports: [PaymentsAddModalComponent]
})
export class PaymentsAddModalModule {

}
