import { NgModule } from '@angular/core';

import { ResourcesComponent } from '././resources.component';
import { ResourcesRoutingModule } from './resources-routing.module';
import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzInputModule } from 'ng-zorro-antd/input';
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
    NzTagModule,
    ReactiveFormsModule,
    NzInputModule
  ],
  exports: [ResourcesComponent],
  providers: [ PermissionsHttpService ]
})
export class ResourcesModule { }
