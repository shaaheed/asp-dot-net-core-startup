import { Component, Input, ViewChild } from '@angular/core';
import { NzAutocompleteComponent } from 'ng-zorro-antd/auto-complete';
import { AntControlComponent } from '../ant-control.component';
import { InputConfig } from '../form-page/control.config';

@Component({
  selector: 'app-autocomplete',
  templateUrl: './autocomplete.component.html'
})
export class AutocompleteComponent extends AntControlComponent {

  @Input() type = 'text';
  @Input() prefix: string;
  @Input() suffix: string;
  @Input() idKey: string = 'id';
  @Input() labelKey: string = 'name';
  @Input() options: any[] = [];

  @ViewChild('autocomplete', { static: true }) autocomplete: NzAutocompleteComponent;

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