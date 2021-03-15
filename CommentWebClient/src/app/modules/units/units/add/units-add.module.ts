import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UnitsAddComponent } from './units-add.component';
import { UnitsAddRoutingModule } from './units-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SaveCancelButtonModule } from 'src/app/shared/save-cancel-button/save-cancel-button.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { TextModule } from 'src/app/shared/text/text.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    UnitsAddComponent
  ],
  imports: [
    UnitsAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule,
    TextModule,
    SelectControlModule
  ],
  exports: [UnitsAddComponent]
})
export class UnitsAddModule {

}
