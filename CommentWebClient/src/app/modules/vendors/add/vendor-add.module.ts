import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VendorAddComponent } from './vendor-add.component';
import { VendorAddRoutingModule } from './vendor-add-routing.module';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { VendorService } from '../vendor.service';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzTagModule } from 'ng-zorro-antd/tag';

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
    TableHeaderModule,
    SharedModule,
    BoxLoaderModule,
    NzButtonModule,
    NzTagModule
  ],
  exports: [VendorAddComponent],
  providers: [VendorService]
})
export class VendorAddModule {

}
