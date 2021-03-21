import { Component, Input, ViewChild } from '@angular/core';
import { AntControlComponent } from '../ant-control.component';

@Component({
  selector: 'app-date-picker',
  templateUrl: './date.component.html'
})
export class DatePickerComponent extends AntControlComponent {

  @Input() dateFormat: string =  'dd-MM-yyyy';

}