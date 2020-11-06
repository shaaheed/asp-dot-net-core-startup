import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InvoicesAddComponent } from './invoices-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { InvoicesAddRoutingModule } from './invoices-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    InvoicesAddComponent
  ],
  imports: [
    InvoicesAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    NzMenuModule,
    NzDropDownModule,
    SharedModule,
    NzSelectModule,
    BoxLoaderModule,
    NzDatePickerModule,
    NzButtonModule,
    NzModalModule
  ],
  exports: [InvoicesAddComponent],
  providers: [InvoiceService]
})
export class InvoicesAddModule {

}
