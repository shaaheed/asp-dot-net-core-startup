import { NgModule } from '@angular/core';

import { OperationsComponent } from './operations.component';
import { OperationsRoutingModule } from './operations-routing.module';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { OperationsAddComponent } from './add/operations-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PermissionsHttpService } from 'src/services/http/permissions-http.service';

@NgModule({
  declarations: [
    OperationsComponent,
    OperationsAddComponent
  ],
  imports: [
    CommonModule,
    OperationsRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule
  ],
  exports: [OperationsComponent],
  entryComponents: [OperationsAddComponent],
  providers: [ PermissionsHttpService ]
})
export class OperationsModule { }
