import { Component } from '@angular/core';
import { FormComponent as Form } from '../form.component';
import { ControlConfig } from './control.config';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
})
export class FormComponent extends Form {

  controls: ControlConfig[];

}