import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzTagModule } from 'ng-zorro-antd/tag';
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
    NzSelectModule,
    NzDropDownModule,
    NzTagModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    NzPopoverModule
  ],
  exports: [ResourcesGroupsComponent],
  entryComponents: [ResourcesGroupsAddComponent],
  providers: [ PermissionsHttpService ]
})
export class ResourcesGroupsModule { }
