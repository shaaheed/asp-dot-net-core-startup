import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { DrawerComponent } from './drawer.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { PerfectScrollbarConfigInterface, PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { NzIconModule } from 'ng-zorro-antd/icon';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
}

@NgModule({
  declarations: [
    DrawerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PerfectScrollbarModule,
    NzIconModule
  ],
  exports: [DrawerComponent],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
  ],
})
export class DrawerModule {

}
