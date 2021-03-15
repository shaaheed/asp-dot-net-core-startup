import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UnitTypesAddComponent } from './types-add.component';
import { UnitTypesAddRoutingModule } from './types-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SaveCancelButtonModule } from 'src/app/shared/save-cancel-button/save-cancel-button.module';
import { InputModule } from 'src/app/shared/input/input.module';

@NgModule({
  declarations: [
    UnitTypesAddComponent
  ],
  imports: [
    UnitTypesAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule,
  ],
  exports: [UnitTypesAddComponent]
})
export class UnitTypesAddModule {

}
