import { NgModule } from '@angular/core';
import { LayoutDefaultRoutingModule } from './layout-default-routing.module';
import { LayoutDefaultComponent } from './layout-default.component';
import { NzMenuModule, NzLayoutModule, NgZorroAntdModule, NzPopoverModule, NzSelectModule, NzFormModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  imports: [
    LayoutDefaultRoutingModule,
    NzLayoutModule,
    NzMenuModule,
    NgZorroAntdModule,
    NzPopoverModule,
    NzSelectModule,
    NzFormModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ],
  declarations: [
    LayoutDefaultComponent
  ],
  exports: [LayoutDefaultComponent]
})
export class LayoutDefaultModule { }
