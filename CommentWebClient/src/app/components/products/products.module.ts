import { NgModule } from '@angular/core';

import { ProductsComponent } from './products.component';
import { ProductsRoutingModule } from './products-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzToolTipModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsHttpService } from 'src/services/http/products-http.service';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    SharedModule,
    NzToolTipModule,
    BoxLoaderModule
  ],
  exports: [ProductsComponent],
  providers: [ProductsHttpService]
})
export class ProductsModule { }
