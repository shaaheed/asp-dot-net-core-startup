import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { CheckboxModule } from 'src/app/shared/checkbox/checkbox.module';
import { TextModule } from 'src/app/shared/text/text.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AppFormModule } from 'src/app/shared/form/form.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { ProductPurchaseInfoAddComponent } from './purchase-info.component';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzSegmentedModule } from 'ng-zorro-antd/segmented';
import { NzTableModule } from 'ng-zorro-antd/table';

@NgModule({
  declarations: [
    ProductPurchaseInfoAddComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    InputModule,
    CheckboxModule,
    TextModule,
    SelectControlModule,
    NzIconModule,
    AppFormModule,
    NzSpaceModule,
    NzSegmentedModule,
    NzTableModule
  ],
  exports: [ProductPurchaseInfoAddComponent]
})
export class ProductsPurchaseInfoModule {

}
