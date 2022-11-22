import { Component, EventEmitter, Input, Output, TemplateRef } from '@angular/core';
import { AntControlComponent } from '../ant-control.component';
import { InputConfig } from '../form-page/control.config';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html'
})
export class InputComponent extends AntControlComponent {

  @Input() type = 'text';
  @Input() prefix: string;
  @Input() suffix: string | TemplateRef<any>;
  @Input() canSuffixShow: boolean = true;
  @Input() inputStyle = {};

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