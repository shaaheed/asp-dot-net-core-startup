import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/services/customer.service';

@Component({
  selector: 'app-customers-add',
  templateUrl: './customers-add.component.html'
})
export class CustomersAddComponent extends FormComponent {

  loading: boolean = false;

  constructor(
    private customerService: CustomerService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.requiredValidator.bind(this)],
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
        request: this.customerService.add(body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.created', x => this._messageService.success(x));
        }
      },
      {
        request: this.customerService.update(this.id, body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.updated', x => this._messageService.success(x));
        }
      }
    );
  }

  requiredValidator(control: FormControl) {
    if (!control.value) {
      return this.constructError('please.give.a.name');
    }
    else if (control.value.length < 3) {
      return this.constructError('name.must.be.greater.than.3.letters');
    }
    return of(true);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.customerService.get(id),
      (res: any) => {
        this.setValues(this.form.controls, res);
        this.loading = false;
      }
    )
  }

  cancel() {
    this._router.navigateByUrl('customers');
  }

}
