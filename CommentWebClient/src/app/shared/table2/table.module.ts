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
import { TableActionsModule } from 'src/app/shared/table-actions/table-actions.module';
import { TableRoutingModule } from './table-routing.module';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FilterModule } from '../filter/filter.module';

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
    TableRoutingModule,
    NzPopoverModule,
    NzCollapseModule,
    NzCheckboxModule,
    NzInputModule,
    FilterModule
  ],
  exports: [TableComponent]
})
export class TableModule { }
