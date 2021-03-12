import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { RolesAddComponent } from './roles-add.component';
import { RolesAddRoutingModule } from './roles-add-routing.module';

@NgModule({
  declarations: [
    RolesAddComponent
  ],
  imports: [
    RolesAddRoutingModule,
    CommonModule,
    FormsModule,
    NzInputModule,
    NzButtonModule,
    NzFormModule,
    NzSelectModule,
    SharedModule,
    ReactiveFormsModule,
  ],
  exports: [RolesAddComponent]
})
export class RolesAddModule { }
