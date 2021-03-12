import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { InputComponent } from './input.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { NzInputModule } from 'ng-zorro-antd/input';
import { getLang } from 'src/services/utilities.service';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    InputComponent
  ],
  imports: [
    CommonModule,
    NzInputModule,
    NzFormModule,
    ReactiveFormsModule,
    TranslateModule,
    NzToolTipModule,
    NzIconModule
  ],
  exports: [InputComponent]
})
export class InputModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}
