import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { SettingsComponent } from './settings.component';
import { TableModule } from 'src/app/shared/table/table.module';
import { TimeAgoPipeModule } from 'src/pipes/time-ago.pipe';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { TranslateModule } from '@ngx-translate/core';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { PerfectScrollbarConfigInterface, PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
}

@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    TimeAgoPipeModule,
    MomentPipeModule,
    TranslateModule,
    NzToolTipModule,
    NzInputModule,
    NzSwitchModule,
    NzIconModule,
    NzFormModule,
    NzMenuModule,
    PerfectScrollbarModule
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
  ],
  exports: [SettingsComponent]
})
export class SettingsModule { }
