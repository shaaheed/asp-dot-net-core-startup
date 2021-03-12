import { Component, Input, forwardRef, Output, EventEmitter, Self } from '@angular/core';
import { ControlValueAccessor, NgControl, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  // providers: [
  //   {
  //     provide: NG_VALUE_ACCESSOR,
  //     useExisting: forwardRef(() => InputComponent),
  //     multi: true
  //   }
  // ]
})
export class InputComponent implements ControlValueAccessor {

  @Input() label;
  @Input() type = 'text';
  @Input() placeholder;
  @Output() onChange = new EventEmitter();
  @Input() mandatory: boolean = false;
  @Input() disabled: boolean = false;
  @Input() beforeText: string;
  @Input() tooltip: string;

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