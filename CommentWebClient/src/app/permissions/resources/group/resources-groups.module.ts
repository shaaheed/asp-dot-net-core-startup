import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzPopoverModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PermissionsHttpService } from 'src/services/http/permissions-http.service';
import { ResourcesGroupsComponent } from './resources-groups.component';
import { ResourcesGroupsAddComponent } from './add/resources-groups-add.component';
import { ResourcesGroupsRoutingModule } from './resources-groups-routing.module';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';

@NgModule({
  declarations: [
    ResourcesGroupsComponent,
    ResourcesGroupsAddComponent
  ],
  imports: [
    CommonModule,
    ResourcesGroupsRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    TableHeaderModule,
    NzPopoverModule,
    NgZorroAntdModule
  ],
  exports: [ResourcesGroupsComponent],
  entryComponents: [ResourcesGroupsAddComponent],
  providers: [ PermissionsHttpService ]
})
export class ResourcesGroupsModule { }
