import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { TableActionsComponent } from './table-actions.component';
import { FormsModule } from '@angular/forms';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    TableActionsComponent
  ],
  imports: [
    CommonModule,
    NzIconModule,
    NzButtonModule,
    NzDropDownModule,
    SharedModule,
    FormsModule
  ],
  exports: [TableActionsComponent]
})
export class TableActionsModule { }
