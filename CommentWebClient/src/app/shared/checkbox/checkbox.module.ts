import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CheckboxComponent } from './checkbox.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { getLang } from 'src/services/utilities.service';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    CheckboxComponent
  ],
  imports: [
    CommonModule,
    NzCheckboxModule,
    NzFormModule,
    ReactiveFormsModule,
    TranslateModule,
    NzToolTipModule,
    NzIconModule
  ],
  exports: [CheckboxComponent]
})
export class CheckboxModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}
