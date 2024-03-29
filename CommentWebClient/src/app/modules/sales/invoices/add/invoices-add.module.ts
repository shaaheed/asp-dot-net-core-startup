import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InvoicesAddComponent } from './invoices-add.component';
import { TableHeaderModule } from 'src/app/shared-components/table-header/table-header.module';
import { InvoicesAddRoutingModule } from './invoices-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BoxLoaderModule } from 'src/app/shared/box-loader.component';
import { AppFormModule } from 'src/app/shared/form/form.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { DatePickerModule } from 'src/app/shared/date/date.module';
import { InputModule } from 'src/app/shared/input/input.module';
import { TextModule } from 'src/app/shared/text/text.module';
import { AutocompleteModule } from 'src/app/shared/autocomplete/autocomplete.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { ButtonSelectModule } from 'src/app/shared/button-select/button-select.module';

@NgModule({
  declarations: [
    InvoicesAddComponent
  ],
  imports: [
    InvoicesAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    TableHeaderModule,
    NzMenuModule,
    NzDropDownModule,
    SharedModule,
    NzSelectModule,
    NzInputModule,
    BoxLoaderModule,
    NzDatePickerModule,
    NzButtonModule,
    NzModalModule,
    AppFormModule,
    SelectControlModule,
    DatePickerModule,
    ButtonSelectModule,
    InputModule,
    TextModule,
    NzIconModule,
    AutocompleteModule,
    NzAutocompleteModule
  ],
  exports: [InvoicesAddComponent]
})
export class InvoicesAddModule {

}
