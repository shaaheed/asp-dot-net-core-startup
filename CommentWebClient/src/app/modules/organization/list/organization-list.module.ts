import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { OrganizationListComponent } from './organization-list.component';
import { OrganizationListRoutingModule } from './organization-list-routing.module';
import { OrganizationHttpService } from 'src/app/modules/organization/organization-http.service';
import { TableModule } from 'src/app/shared/table/table.module';
import { TimeAgoPipeModule } from 'src/pipes/time-ago.pipe';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { TranslateModule } from '@ngx-translate/core';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSwitchModule } from 'ng-zorro-antd/switch';

@NgModule({
  declarations: [
    OrganizationListComponent
  ],
  imports: [
    CommonModule,
    OrganizationListRoutingModule,
    TableModule,
    TimeAgoPipeModule,
    MomentPipeModule,
    TranslateModule,
    NzToolTipModule,
    NzInputModule,
    NzSwitchModule,
    NzFormModule
  ],
  exports: [OrganizationListComponent],
  providers: [OrganizationHttpService]
})
export class OrganizationListModule { }
