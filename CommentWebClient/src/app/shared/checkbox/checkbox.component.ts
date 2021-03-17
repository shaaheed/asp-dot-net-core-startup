import { Component, Input } from '@angular/core';
import { ControlComponent } from '../control.component';
import { CheckboxConfig } from '../form-page/control.config';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html'
})
export class CheckboxComponent extends ControlComponent {

  @Input() info: string;

  ngOnInit() {
    if (this.config) {
      const config = <CheckboxConfig>this.config;
      this.info = config.info;
    }
    super.ngOnInit();
  }

}