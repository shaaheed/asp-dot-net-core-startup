import { Component, Input, Output, EventEmitter, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html'
})
export class InputComponent implements ControlValueAccessor {

  @Input() label;
  @Input() type = 'text';
  @Input() placeholder;
  @Output() onChange = new EventEmitter();
  @Input() mandatory: boolean = false;
  @Input() beforeText: string;
  @Input() tooltip: string;

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
    console.log(this.label, this._disable);
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
  }

  writeValue(value: any) {
    this._value = value;
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {

  }

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