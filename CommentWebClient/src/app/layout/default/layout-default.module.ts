import { NgModule } from '@angular/core';
import { LayoutDefaultRoutingModule } from './layout-default-routing.module';
import { LayoutDefaultComponent } from './layout-default.component';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { PerfectScrollbarConfigInterface, PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { SettingsModule } from 'src/app/modules/settings/settings/settings.module';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { QuickCreateModule } from 'src/app/shared/quick-create/quick-create.module';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
}

@NgModule({
  imports: [
    LayoutDefaultRoutingModule,
    NzLayoutModule,
    NzMenuModule,
    NzPopoverModule,
    NzSelectModule,
    NzFormModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    NzDropDownModule,
    NzAvatarModule,
    NzInputModule,
    NzBadgeModule,
    NzIconModule,
    NzToolTipModule,
    NzDrawerModule,
    PerfectScrollbarModule,
    NzBreadCrumbModule,
    SettingsModule,
    NzSpaceModule,
    QuickCreateModule
  ],
  declarations: [
    LayoutDefaultComponent
  ],
  exports: [LayoutDefaultComponent],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    }
  ]
})
export class LayoutDefaultModule { }
