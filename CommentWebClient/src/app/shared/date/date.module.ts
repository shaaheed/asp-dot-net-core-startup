import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DatePickerComponent } from './date.component';
import { TranslateModule } from '@ngx-translate/core';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    DatePickerComponent
  ],
  imports: [
    CommonModule,
    NzDatePickerModule,
    NzFormModule,
    ReactiveFormsModule,
    TranslateModule,
    NzToolTipModule,
    NzIconModule
  ],
  exports: [DatePickerComponent]
})
export class DatePickerModule {}
