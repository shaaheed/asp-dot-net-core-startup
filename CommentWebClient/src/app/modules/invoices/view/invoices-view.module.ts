import { NgModule } from '@angular/core';

import { InvoicesViewComponent } from './invoices-view.component';
import { InvoicesViewRoutingModule } from './invoices-view-routing.module';
import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { PaymentsAddModalModule } from '../payments-add-modal/payments-add-modal.module';

@NgModule({
  declarations: [
    InvoicesViewComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    NzToolTipModule,
    InvoicesViewRoutingModule,
    PaymentsAddModalModule,
    BoxLoaderModule,
    NzTagModule,
    NzDropDownModule,
    NzDrawerModule
  ],
  exports: [InvoicesViewComponent],
  providers: [InvoiceService]
})
export class InvoicesViewModule { }
