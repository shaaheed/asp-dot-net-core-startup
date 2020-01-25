import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersAddComponent } from './users-add.component';
import { UsersHttpService } from 'src/services/http/users-http.service';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { UsersAddRoutingModule } from './users-add-routing.module';

@NgModule({
  declarations: [
    UsersAddComponent
  ],
  imports: [
    UsersAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule
  ],
  exports: [UsersAddComponent],
  providers: [UsersHttpService]
})
export class UsersAddModule { }
