import { Component, Input } from '@angular/core';
import { AntControlComponent } from '../ant-control.component';
import { CheckboxConfig } from '../form-page/control.config';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html'
})
export class CheckboxComponent extends AntControlComponent {

  @Input() info: string;

  ngOnInit() {
    if (this.config) {
      const config = <CheckboxConfig>this.config;
      this.info = config.info;
    }
    super.ngOnInit();
  }

}