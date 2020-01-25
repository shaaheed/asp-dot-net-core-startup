import { NgModule } from '@angular/core';

import { ResourcesComponent } from '././resources.component';
import { ResourcesRoutingModule } from './resources-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PermissionsHttpService } from 'src/services/http/permissions-http.service';

@NgModule({
  declarations: [
    ResourcesComponent
  ],
  imports: [
    CommonModule,
    ResourcesRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule
  ],
  exports: [ResourcesComponent],
  providers: [ PermissionsHttpService ]
})
export class ResourcesModule { }
