import { Input, Output, EventEmitter, Directive } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import { ControlConfig } from './form-page/control.config';

@Directive()
export class ControlComponent implements ControlValueAccessor {

  @Input() label;
  @Input() placeholder;
  @Output() onChange = new EventEmitter();
  @Input() mandatory: boolean = false;
  @Input() tooltip: string;
  @Input() config: ControlConfig;

  private _value;
  private propagateChange = (_: any) => { };
  private _disable = false;

  @Input() set disable(value: boolean) {
    const action = value ? 'disable' : 'enable';
    if (this.ngControl?.control) {
      this.ngControl.control[action]();
    }
    this._disable = value ?? false;
  }

  get disable(): boolean {
    return this._disable;
  }

  get value() {
    return this._value;
  }

  set value(value) {
    this._value = value;
    this.propagateChange(this._value);
  }

  constructor(public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }

  ngOnInit() {
    if (this.config) {
      this.label = this.config.label;
      this.placeholder = this.config.placeholder;
      this.tooltip = this.config.tooltip;
      this.mandatory = this.config.mandatory;
      if(this.config.controlAccessor) {
        this.config.controlAccessor(this);
      }
    }
  }

  writeValue(value: any) {
    this._value = value;
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}

  onValueChange(e) {
    this._value = e;
    if (this.onChange) {
      this.onChange.emit(e);
    }
  }

  setValue(value) {
    this._value = value;
    return this;
  }

}