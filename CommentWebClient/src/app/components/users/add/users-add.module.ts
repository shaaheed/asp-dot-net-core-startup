import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTagModule } from 'ng-zorro-antd/tag';
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
    NzInputModule,
    NzTagModule,
    NzFormModule,
    NzSelectModule,
    ReactiveFormsModule,
    TableHeaderModule
  ],
  exports: [UsersAddComponent],
  providers: [UsersHttpService]
})
export class UsersAddModule { }
