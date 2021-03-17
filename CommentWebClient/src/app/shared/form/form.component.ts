import { Component, Input, TemplateRef } from '@angular/core';
import { FormComponent } from '../form.component';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
})
export class AppFormComponent extends FormComponent {

  @Input() component: FormComponent;
  @Input() content: TemplateRef<any>;

}