import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { SharedModule } from '../shared.module';
import { AppFormComponent } from './form.component';
import { InputModule } from '../input/input.module';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';

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
    InputModule,
    NzButtonModule,
    NzIconModule
  ],
  exports: [AppFormComponent]
})
export class AppFormModule {}
