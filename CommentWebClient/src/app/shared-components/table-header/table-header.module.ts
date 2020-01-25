import { NgModule } from '@angular/core';

import { TableHeaderComponent } from './table-header.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NzFormModule, NgZorroAntdModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [
    TableHeaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule
  ],
  exports: [TableHeaderComponent],
  providers: []
})
export class TableHeaderModule { }
