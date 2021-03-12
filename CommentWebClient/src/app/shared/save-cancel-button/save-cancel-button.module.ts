import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SaveCancelButtonComponent } from './save-cancel-button.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { getLang } from 'src/services/utilities.service';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzButtonModule } from 'ng-zorro-antd/button';

@NgModule({
  declarations: [
    SaveCancelButtonComponent
  ],
  imports: [
    CommonModule,
    NzButtonModule,
    NzFormModule,
    ReactiveFormsModule,
    TranslateModule
  ],
  exports: [SaveCancelButtonComponent]
})
export class SaveCancelButtonModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}
