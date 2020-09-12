import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VendorAddComponent } from './vendor-add.component';
import { VendorAddRoutingModule } from './vendor-add-routing.module';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { VendorService } from '../vendor.service';

@NgModule({
  declarations: [
    VendorAddComponent
  ],
  imports: [
    VendorAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    SharedModule,
    BoxLoaderModule
  ],
  exports: [VendorAddComponent],
  providers: [VendorService]
})
export class VendorAddModule {

}
