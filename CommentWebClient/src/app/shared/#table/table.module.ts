import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { TableComponent } from './table.component';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { TableRowComponent, TableRowModule } from './table-row.component';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { TableActionsModule } from 'src/app/shared/table-actions/table-actions.module';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    TableComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    SharedModule,
    NzToolTipModule,
    NzButtonModule,
    NzDropDownModule,
    BoxLoaderModule,
    NzIconModule,
    TableActionsModule,
    TableRowModule
  ],
  exports: [TableComponent, TableRowComponent]
})
export class TableModule { }
