import { Component, EventEmitter, Input, Output, TemplateRef, ViewChild } from '@angular/core';
import { NzAutocompleteComponent, NzAutocompleteOptionComponent } from 'ng-zorro-antd/auto-complete';
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
  @Output() selectionChange: EventEmitter<any> = new EventEmitter(true);
  @Output() searchTermChange: EventEmitter<string> = new EventEmitter(true);
  @Input() overlayClassName: string = 'autocompleteOverlay';
  @Input() optionTemplate: TemplateRef<any> = null;

  @ViewChild('autocomplete', { static: true }) autocomplete: NzAutocompleteComponent;
  overlayStyle = {minWidth: '500px'}

  ngOnInit() {
    if (this.config) {
      const config = <InputConfig>this.config;
      this.prefix = config.prefix;
      this.suffix = config.suffix;
      this.type = config.type;
    }
    super.ngOnInit();
  }

  onChangeSearchTerm(searchTerm) {
    if (this.searchTermChange) {
      this.searchTermChange.emit(searchTerm);
    }
  }

  onSelectionChanged(option: NzAutocompleteOptionComponent) {
    const value = option.nzValue
    const item = this.options.filter(x => x.id == value)[0];
    if (item && this.selectionChange) {
      this.selectionChange.emit(item);
    }
    this.setControlValue(value);
    super.onValueChange(value);
  }

  private setControlValue(value) {
    if (value) {
      let _value = this.autocomplete.getOption(value)?.nzLabel;
      if (_value && this.ngControl) {
        this.ngControl.control.setValue(_value);
      }
    }
  }

}