import { Component, Input, Output, EventEmitter, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html'
})
export class TextComponent implements ControlValueAccessor {

  @Input() label;
  @Input() placeholder;
  @Output() onChange = new EventEmitter();
  @Input() mandatory: boolean = false;
  @Input() disabled: boolean = false;

  private _value;
  private propagateChange = (_: any) => { };

  get value() {
    return this._value;
  }

  set value(value) {
    this._value = value;
    this.propagateChange(this._value);
  }

  constructor(@Self() public ngControl: NgControl) {
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