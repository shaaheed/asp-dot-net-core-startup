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
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { TableActionsModule } from 'src/app/shared/table-actions.component';
import { TableRoutingModule } from './table-routing.module';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';

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
    TableRoutingModule
  ],
  exports: [TableComponent]
})
export class TableModule { }
