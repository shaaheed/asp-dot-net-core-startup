import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SelectComponent } from './select.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzFormModule } from 'ng-zorro-antd/form';

@NgModule({
  declarations: [
    SelectComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SharedModule
  ],
  exports: [SelectComponent]
})
export class SelectModule { }
