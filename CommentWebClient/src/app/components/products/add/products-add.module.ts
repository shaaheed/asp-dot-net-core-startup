import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzButtonModule } from 'ng-zorro-antd/button';
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
    NzButtonModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    SharedModule,
    BoxLoaderModule
  ],
  exports: [ProductsAddComponent],
  providers: [ProductsHttpService]
})
export class ProductsAddModule {

}
