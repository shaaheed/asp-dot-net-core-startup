import { NgModule } from '@angular/core';

import { TableHeaderComponent } from './table-header.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';

@NgModule({
  declarations: [
    TableHeaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    NzInputModule,
    ReactiveFormsModule,
    NzButtonModule
  ],
  exports: [TableHeaderComponent],
  providers: []
})
export class TableHeaderModule { }
