import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { OrganizationHttpService } from 'src/app/modules/organization/organization-http.service';
import { m } from 'src/constants/message';

@Component({
  selector: 'app-organization-add',
  templateUrl: './organization-add.component.html'
})
export class OrganizationAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;

  constructor(
    private organizationHttpService: OrganizationHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    super.ngOnInit(this.activatedRoute.snapshot);
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.customerNameValidator.bind(this)],
      email: [],
      mobile: [],
      contact: []
    });

    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.organizationHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(m.successfully_created);
        }
      },
      {
        request: this.organizationHttpService.update(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(m.successfully_updated);
        }
      }
    );
  }

  customerNameValidator(control: FormControl) {
    if (!control.value) {
      return this.error(m.please_give_a_name);
    }
    else if (control.value.length < 3) {
      return this.error(m.must_be_greater_than_x0_letters, { x0: 3 });
    }
    return of(true);
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.organizationHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      )
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this._router.navigateByUrl('organizations');
  }

}
