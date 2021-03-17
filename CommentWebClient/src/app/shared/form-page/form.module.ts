import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { SaveCancelButtonModule } from '../save-cancel-button/save-cancel-button.module';
import { SharedModule } from '../shared.module';
import { FormPageComponent } from './form.component';
import { InputModule } from '../input/input.module';
import { TextModule } from '../text/text.module';
import { FormPageRoutingModule } from './form-routing.module';

@NgModule({
  declarations: [
    FormPageComponent
  ],
  imports: [
    FormPageRoutingModule,
    CommonModule,
    SharedModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule,
    TextModule
  ],
  exports: [FormPageComponent]
})
export class FormPageModule {}
