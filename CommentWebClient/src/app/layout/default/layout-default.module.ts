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
import { NzIconModule } from 'ng-zorro-antd/icon';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


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
    NzIconModule
  ],
  declarations: [
    LayoutDefaultComponent
  ],
  exports: [LayoutDefaultComponent]
})
export class LayoutDefaultModule { }
