import { Directive, ViewChild } from '@angular/core';
import { NzFormControlComponent } from 'ng-zorro-antd/form';
import { ControlComponent } from './control.component';

@Directive()
export class AntControlComponent extends ControlComponent {

  @ViewChild('antFormControl', { static: true }) antFormControl: NzFormControlComponent;

  ngOnInit() {
    super.ngOnInit();
    if (this.mandatory
      || this.ngControl.asyncValidator
      || this.ngControl.validator
      || this.ngControl.errors) {
      // this.antFormControl.nzHasFeedback = true;
    }
  }

}