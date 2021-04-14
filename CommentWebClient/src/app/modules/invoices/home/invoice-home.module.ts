import { NgModule } from '@angular/core';

import { InvoiceHomeComponent } from './invoice-home.component';
import { InvoiceHomeRoutingModule } from './invoice-home-routing.module';
import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzTableModule } from 'ng-zorro-antd/table';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { RouterModule } from '@angular/router';
import { InvoiceIdResolver } from './invoice-id.resolver';
import { NzRadioModule } from 'ng-zorro-antd/radio';

@NgModule({
  declarations: [
    InvoiceHomeComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    NzToolTipModule,
    InvoiceHomeRoutingModule,
    BoxLoaderModule,
    RouterModule,
    NzRadioModule
  ],
  exports: [InvoiceHomeComponent],
  providers: [InvoiceIdResolver]
})
export class InvoiceHomeModule { }
