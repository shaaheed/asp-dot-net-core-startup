import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SaveCancelButtonComponent } from './save-cancel-button.component';
import { TranslateModule } from '@ngx-translate/core';
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
export class SaveCancelButtonModule {}
