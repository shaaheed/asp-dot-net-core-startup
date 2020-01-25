import { NgModule } from '@angular/core';

import { UsersGroupsComponent } from './users-groups.component';
import { UsersGroupsRoutingModule } from './users-groups-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
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
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule
  ],
  exports: [UsersGroupsComponent],
  entryComponents: [UsersGroupsAddComponent],
  providers: [UsersHttpService]
})
export class UsersGroupsModule { }
