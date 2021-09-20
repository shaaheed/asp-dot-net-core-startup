import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { ContactDrawerComponent } from './contact-drawer.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { DrawerModule } from 'src/app/shared/drawer/drawer.module';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';

@NgModule({
  declarations: [
    ContactDrawerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    NzIconModule,
    DrawerModule,
    NzAvatarModule
  ],
  exports: [ContactDrawerComponent]
})
export class ContactDrawerModule {

}
