import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrganizationAddComponent } from './organization-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { OrganizationAddRoutingModule } from './organization-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { OrganizationService } from 'src/services/organization.service';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzButtonModule } from 'ng-zorro-antd/button';

@NgModule({
  declarations: [
    OrganizationAddComponent
  ],
  imports: [
    OrganizationAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    SharedModule,
    BoxLoaderModule,
    NzButtonModule
  ],
  exports: [OrganizationAddComponent],
  providers: [OrganizationService]
})
export class OrganizationAddModule {

}
