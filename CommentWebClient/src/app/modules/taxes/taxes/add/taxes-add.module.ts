import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TaxesAddComponent } from './taxes-add.component';
import { TaxesAddRoutingModule } from './taxes-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SaveCancelButtonModule } from 'src/app/shared/save-cancel-button/save-cancel-button.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { TextModule } from 'src/app/shared/text/text.module';
import { CheckboxModule } from 'src/app/shared/checkbox/checkbox.module';
import { AppFormModule } from 'src/app/shared/form/form.module';

@NgModule({
  declarations: [
    TaxesAddComponent
  ],
  imports: [
    TaxesAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule,
    TextModule,
    CheckboxModule,
    AppFormModule
  ],
  exports: [TaxesAddComponent]
})
export class TaxesAddModule {

}
