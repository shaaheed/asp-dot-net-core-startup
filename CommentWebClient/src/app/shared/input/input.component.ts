import { Component, Input } from '@angular/core';
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

  ngOnInit() {
    if (this.config) {
      const config = <InputConfig>this.config;
      this.prefix = config.prefix;
      this.suffix = config.suffix;
      this.type = config.type;
    }
    super.ngOnInit();
  }

}