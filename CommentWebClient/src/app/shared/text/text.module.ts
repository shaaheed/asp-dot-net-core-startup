import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TextComponent } from './text.component';
import { TranslateModule } from '@ngx-translate/core';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';

@NgModule({
  declarations: [
    TextComponent
  ],
  imports: [
    CommonModule,
    NzInputModule,
    NzFormModule,
    ReactiveFormsModule,
    TranslateModule
  ],
  exports: [TextComponent]
})
export class TextModule {}
