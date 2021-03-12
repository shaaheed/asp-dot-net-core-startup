import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersAddComponent } from './users-add.component';
import { UsersAddRoutingModule } from './users-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SaveCancelButtonModule } from 'src/app/shared/save-cancel-button/save-cancel-button.module';
import { InputModule } from 'src/app/shared/input/input.module';

@NgModule({
  declarations: [
    UsersAddComponent
  ],
  imports: [
    UsersAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule
  ],
  exports: [UsersAddComponent]
})
export class UsersAddModule { }
