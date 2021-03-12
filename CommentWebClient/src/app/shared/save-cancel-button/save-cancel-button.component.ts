import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-save-cancel-button',
  templateUrl: './save-cancel-button.component.html',
})
export class SaveCancelButtonComponent {

  @Input() submitting;
  @Input() submitButtonText;
  @Output() onSubmit = new EventEmitter();
  @Output() onCancel = new EventEmitter();

  ngOnInit() {
  }

  submit() {
    this.onSubmit.emit();
  }

  cancel() {
    this.onCancel.emit();
  }


}