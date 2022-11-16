import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UnitsAddComponent } from './units-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { UnitsAddRoutingModule } from './units-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { AppFormModule } from 'src/app/shared/form/form.module';
import { ButtonSelectModule } from '../../../shared/button-select/button-select.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { TextModule } from 'src/app/shared/text/text.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { CheckboxModule } from 'src/app/shared/checkbox/checkbox.module';

@NgModule({
  declarations: [
    UnitsAddComponent
  ],
  imports: [
    UnitsAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    SharedModule,
    NzInputModule,
    BoxLoaderModule,
    NzButtonModule,
    NzModalModule,
    AppFormModule,
    ButtonSelectModule,
    InputModule,
    TextModule,
    NzIconModule,
    CheckboxModule
  ],
  exports: [UnitsAddComponent]
})
export class UnitsAddModule {

}
