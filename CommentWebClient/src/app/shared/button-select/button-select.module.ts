import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ButtonSelectComponent } from './button-select.component';
import { TranslateModule } from '@ngx-translate/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    ButtonSelectComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SelectControlModule,
    TranslateModule,
    NzButtonModule,
    NzIconModule
  ],
  exports: [ButtonSelectComponent]
})
export class ButtonSelectModule {

}
