import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { SaveCancelButtonModule } from '../save-cancel-button/save-cancel-button.module';
import { SharedModule } from '../shared.module';
import { AppFormComponent } from './form.component';
import { InputModule } from '../input/input.module';

@NgModule({
  declarations: [
    AppFormComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule
  ],
  exports: [AppFormComponent]
})
export class AppFormModule {}
