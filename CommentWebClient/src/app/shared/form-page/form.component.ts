import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ValidatorService } from 'src/services/validator.service';
import { FormComponent } from '../form.component';
import { ControlConfig } from './control.config';
import { FormPageConfig } from './form.config';

@Component({
  selector: 'app-form-page',
  templateUrl: './form.component.html',
})
export class FormPageComponent extends FormComponent {

  @Input() config: FormPageConfig;

  constructor(
    private activatedRoute: ActivatedRoute,
    private validatorService: ValidatorService
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    if (snapshot?.data?.pageData) {
      this.config = snapshot.data.pageData;
      if (this.config) {
        this.apiUrl = this.config.apiUrl;
        this.objectName = this.config.objectName;
        this.cancelRoute = this.config.cancelRoute;
        if (this.config.onBeforeSubmit) {
          this.onBeforeSubmit = this.config.onBeforeSubmit;
        }
        const _form = {};
        if (this.config.rows?.length
          && this.config.rows[0].columns?.length
          && this.config.rows[0].columns[0].controls?.length) {
          this.config.rows.forEach(row => {
            row.columns.forEach(column => {
              this.addControlsToForm(_form, column.controls);
            });
          });
        }
        else {
          this.addControlsToForm(_form, this.config.controls);
        }
        if (Object.keys(_form).length) {
          this.form = this.fb.group(_form);
        }
      }
    }
    super.ngOnInit(snapshot);
  }

  private addControlsToForm(form: {}, controls?: ControlConfig[]) {
    if (controls?.length) {
      this.config.controls.forEach(control => {
        const options = control.buildOptions ? control.buildOptions(this.validatorService) : [];
        form[control.name] = options;
      });
    }
  }
}