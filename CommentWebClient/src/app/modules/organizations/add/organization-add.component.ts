import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { message } from 'src/constants/message';

@Component({
  selector: 'app-organization-add',
  templateUrl: './organization-add.component.html'
})
export class OrganizationAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  url = "organizations";
  cancelRoute = "organizations";

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], this.customerNameValidator.bind(this)],
      email: [],
      mobile: [],
      contact: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  customerNameValidator(control: FormControl) {
    if (!control.value) {
      return this.error(message.please_give_a_name);
    }
    else if (control.value.length < 3) {
      return this.error(message.must_be_greater_than_x0_letters, { x0: 3 });
    }
    return of(true);
  }

}
