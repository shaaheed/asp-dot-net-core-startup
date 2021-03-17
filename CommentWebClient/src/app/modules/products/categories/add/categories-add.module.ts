import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoriesAddComponent } from './categories-add.component';
import { CategoriesAddRoutingModule } from './categories-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SaveCancelButtonModule } from 'src/app/shared/save-cancel-button/save-cancel-button.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { AppFormModule } from 'src/app/shared/form/form.module';

@NgModule({
  declarations: [
    CategoriesAddComponent
  ],
  imports: [
    CategoriesAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    SharedModule,
    ReactiveFormsModule,
    SaveCancelButtonModule,
    InputModule,
    AppFormModule
  ],
  exports: [CategoriesAddComponent]
})
export class CategoriesAddModule {

}
