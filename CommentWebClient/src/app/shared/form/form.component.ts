import { Component, Input, TemplateRef } from '@angular/core';
import { FormComponent } from '../form.component';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
})
export class AppFormComponent {

  @Input() component: FormComponent;
  @Input() content: TemplateRef<any>;
  @Input() headerStyle: any = {};

}