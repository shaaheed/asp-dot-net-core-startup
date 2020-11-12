import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersAddComponent } from './users-add.component';
import { UsersAddRoutingModule } from './users-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzButtonModule } from 'ng-zorro-antd/button';

@NgModule({
  declarations: [
    UsersAddComponent
  ],
  imports: [
    UsersAddRoutingModule,
    CommonModule,
    FormsModule,
    NzInputModule,
    NzButtonModule,
    NzFormModule,
    NzSelectModule,
    SharedModule,
    ReactiveFormsModule,
  ],
  exports: [UsersAddComponent]
})
export class UsersAddModule { }
