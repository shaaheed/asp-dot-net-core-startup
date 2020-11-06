import { NgModule } from '@angular/core';

import { UsersGroupsComponent } from './users-groups.component';
import { UsersGroupsRoutingModule } from './users-groups-routing.module';
import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersGroupsAddComponent } from './add/users-groups-add.component';
import { UsersHttpService } from 'src/services/http/users-http.service';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';

@NgModule({
  declarations: [
    UsersGroupsComponent,
    UsersGroupsAddComponent
  ],
  imports: [
    CommonModule,
    UsersGroupsRoutingModule,
    NzTableModule,
    FormsModule,
    NzDropDownModule,
    NzFormModule,
    NzInputModule,
    ReactiveFormsModule,
    TableHeaderModule
  ],
  exports: [UsersGroupsComponent],
  entryComponents: [UsersGroupsAddComponent],
  providers: [UsersHttpService]
})
export class UsersGroupsModule { }
