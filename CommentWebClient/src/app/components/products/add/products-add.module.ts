import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsAddComponent } from './products-add.component';
import { ProductsHttpService } from 'src/services/http/products-http.service';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { ProductsAddRoutingModule } from './products-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';

@NgModule({
  declarations: [
    ProductsAddComponent
  ],
  imports: [
    ProductsAddRoutingModule,
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
  exports: [ProductsAddComponent],
  providers: [ProductsHttpService]
})
export class ProductsAddModule {

}
