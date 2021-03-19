import { Component, Input, ViewChild } from '@angular/core';
import { NzFormControlComponent } from 'ng-zorro-antd/form';
import { ControlComponent } from '../control.component';
import { InputConfig } from '../form-page/control.config';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html'
})
export class InputComponent extends ControlComponent {

  @Input() type = 'text';
  @Input() prefix: string;
  @Input() suffix: string;

  @ViewChild('formControl', {static: true}) formControl: NzFormControlComponent;

  ngOnInit() {
    if (this.config) {
      const config = <InputConfig>this.config;
      this.prefix = config.prefix;
      this.suffix = config.suffix;
      this.type = config.type;
    }
    super.ngOnInit();

    if (this.mandatory) {
      this.formControl.nzHasFeedback = true;
    }
    console.log('formControl', this.formControl);
  }

}