import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ProductsHttpService } from 'src/services/http/products-http.service';
import { of } from 'rxjs';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html'
})
export class ProductsAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;

  constructor(
    private productService: ProductsHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.requiredValidator.bind(this)],
      description: [],
      price: [null, [], this.priceValidator.bind(this)],
      isSale: [],
      isBuy: [],
    });

    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.productService.add(body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.created', x => this._messageService.success(x));
        }
      },
      {
        request: this.productService.update(this.id, body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.updated', x => this._messageService.success(x));
        }
      }
    );
  }

  requiredValidator(control: FormControl) {
    if (!control.value) {
      return this.error('please.give.a.name');
    }
    else if (control.value.length < 3) {
      return this.error('name.must.be.greater.than.3.letters');
    }
    return of(true);
  }

  priceValidator(control: FormControl) {
    if (!control.value) {
      return this.error('please.give.a.price');
    }
    else if (isNaN(Number(control.value))) {
      return this.error('price.must.be.numeric');
    }
    return of(true);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.productService.get(id),
      (res: any) => {
        this.setValues(this.form.controls, res);
        this.loading = false;
      }
    )
  }

  cancel() {
    this._router.navigateByUrl('products');
  }

}
