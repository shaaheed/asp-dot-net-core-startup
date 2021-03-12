import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { NzInputModule } from 'ng-zorro-antd/input';
import { getLang } from 'src/services/utilities.service';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormComponent } from './form.component';

@NgModule({
  declarations: [
    FormComponent
  ],
  imports: [
    CommonModule,
    NzInputModule,
    NzFormModule,
    ReactiveFormsModule,
    TranslateModule
  ],
  exports: [FormComponent]
})
export class FormModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}
