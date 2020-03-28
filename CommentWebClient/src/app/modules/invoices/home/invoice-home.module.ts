import { NgModule } from '@angular/core';

import { InvoiceHomeComponent } from './invoice-home.component';
import { InvoiceHomeRoutingModule } from './invoice-home-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzToolTipModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceService } from '../services/invoice.service';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { RouterModule } from '@angular/router';
import { InvoiceIdResolver } from './invoice-id.resolver';

@NgModule({
  declarations: [
    InvoiceHomeComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    NgZorroAntdModule,
    SharedModule,
    NzToolTipModule,
    InvoiceHomeRoutingModule,
    BoxLoaderModule,
    RouterModule
  ],
  exports: [InvoiceHomeComponent],
  providers: [InvoiceService, InvoiceIdResolver]
})
export class InvoiceHomeModule { }
