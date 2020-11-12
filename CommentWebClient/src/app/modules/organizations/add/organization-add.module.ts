import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrganizationAddComponent } from './organization-add.component';
import { OrganizationAddRoutingModule } from './organization-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [
    OrganizationAddComponent
  ],
  imports: [
    OrganizationAddRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    SharedModule,
    NzButtonModule,
    NzInputModule,
    NzIconModule
  ],
  exports: [OrganizationAddComponent]
})
export class OrganizationAddModule {

}
