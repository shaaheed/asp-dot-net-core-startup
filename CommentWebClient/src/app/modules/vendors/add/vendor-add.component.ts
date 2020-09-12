import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { VendorService } from '../vendor.service';

@Component({
  selector: 'app-vendor-add',
  templateUrl: './vendor-add.component.html'
})
export class VendorAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;

  constructor(
    private vendorService: VendorService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
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
        request: this.vendorService.add(body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.created', x => this._messageService.success(x));
        }
      },
      {
        request: this.vendorService.update(this.id, body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.updated', x => this._messageService.success(x));
        }
      }
    );
  }

  customerNameValidator(control: FormControl) {
    if (!control.value) {
      return this.error('please.give.a.name');
    }
    else if (control.value.length < 3) {
      return this.error('name.must.be.greater.than.3.letters');
    }
    return of(true);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.vendorService.get(id),
      (res: any) => {
        this.setValues(this.form.controls, res);
        this.loading = false;
      }
    )
  }

  cancel() {
    this._router.navigateByUrl('vendors');
  }

}
