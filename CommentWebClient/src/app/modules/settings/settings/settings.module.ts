import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { SettingsComponent } from './settings.component';
import { TimeAgoPipeModule } from 'src/pipes/time-ago.pipe';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { TranslateModule } from '@ngx-translate/core';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { DrawerModule } from 'src/app/shared/drawer/drawer.module';

@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    TimeAgoPipeModule,
    MomentPipeModule,
    TranslateModule,
    NzToolTipModule,
    NzInputModule,
    NzIconModule,
    NzMenuModule,
    DrawerModule
  ],
  exports: [SettingsComponent]
})
export class SettingsModule { }
