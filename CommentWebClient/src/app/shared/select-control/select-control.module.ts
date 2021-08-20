import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SelectControlComponent } from './select-control.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    SelectControlComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SharedModule,
    NzSelectModule,
    NzToolTipModule,
    NzIconModule,
    NzDividerModule
  ],
  exports: [SelectControlComponent]
})
export class SelectControlModule { }
