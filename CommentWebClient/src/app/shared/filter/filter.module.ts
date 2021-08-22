import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FilterComponent } from './filter.component';
import { SharedModule } from '../shared.module';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';

@NgModule({
  declarations: [
    FilterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzToolTipModule,
    NzButtonModule,
    NzDropDownModule,
    NzIconModule,
    NzPopoverModule,
    NzCollapseModule,
    NzCheckboxModule,
    NzInputModule,
    SharedModule,
    NzSelectModule,
    NzDatePickerModule,
    NzToolTipModule
  ],
  exports: [FilterComponent]
})
export class FilterModule {
  
}
