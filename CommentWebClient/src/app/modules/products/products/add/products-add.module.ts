import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsAddComponent } from './products-add.component';
import { ProductsHttpService } from 'src/services/http/products-http.service';
import { ProductsAddRoutingModule } from './products-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SaveCancelButtonModule } from 'src/app/shared/save-cancel-button/save-cancel-button.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { CheckboxModule } from 'src/app/shared/checkbox/checkbox.module';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { TextModule } from 'src/app/shared/text/text.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AppFormModule } from 'src/app/shared/form/form.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { ProductsSalesInfoModule } from '../sales-info/sales-info.module';
import { ProductsPurchaseInfoModule } from '../purchase-info/purchase-info.module';

@NgModule({
  declarations: [
    ProductsAddComponent
  ],
  imports: [
    ProductsAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule,
    CheckboxModule,
    NzGridModule,
    NzSpaceModule,
    TextModule,
    SelectControlModule,
    NzIconModule,
    AppFormModule,
    NzTabsModule,
    ProductsSalesInfoModule,
    ProductsPurchaseInfoModule,
  ],
  exports: [ProductsAddComponent],
  providers: [ProductsHttpService]
})
export class ProductsAddModule {

}
