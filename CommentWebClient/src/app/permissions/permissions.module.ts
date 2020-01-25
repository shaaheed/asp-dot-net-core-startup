import { NgModule } from '@angular/core';

import { PermissionsComponent } from './permissions.component';
import { PermissionsRoutingModule } from './permissions-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    PermissionsComponent
  ],
  imports: [
    CommonModule,
    PermissionsRoutingModule
  ],
  exports: [PermissionsComponent],
  providers: []
})
export class PermissionsModule { }
