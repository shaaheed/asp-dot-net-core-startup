import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ValidatorService } from 'src/services/validator.service';
import { CURRENCY } from 'src/app/modules/organizations/organization.service';
import { UntypedFormControl } from '@angular/forms';
import { message } from 'src/constants/message';
import { of } from 'rxjs';
import { ProductSalesInfoAddComponent } from '../sales-info/sales-info.component';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html'
})
export class ProductsAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'products';
  objectName = "product";

  @ViewChild('salesInfo') salesInfo: ProductSalesInfoAddComponent;
  @ViewChild('categoriesSelect') categoriesSelect: SelectControlComponent;
  @ViewChild('unitTypeSelect') unitTypeSelect: SelectControlComponent;

  currency;

  constructor(
    private activatedRoute: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  productInputTest(e?) {
    console.log('inputTest', e)
  }

  ngOnInit(): void {
    this.currency = CURRENCY;
    this.createForm({
      name: [null, [], [
        this.validator.required().bind(this),
        this.validator.min(2).bind(this)
      ]],
      code: [],
      barcode: [],
      categories: [],
      description: [],
      unitTypeId: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.categoriesSelect.register((pagination, search) => {
      return this._httpService.get('products/categories');
    });

    this.unitTypeSelect.register((pagination, search) => {
      return this._httpService.get('systems/units/types');
    });

    // this.purchaseUnitSelect.register((pagination, search) => {
    //   return this._httpService.get(this.getUnitUrl());
    // });

    // this.purchaseTaxSelect.register((pagination, search) => {
    //   return this._httpService.get('taxes');
    // });

    // this.supplierSelect.register((pagination, search) => {
    //   return this._httpService.get('contacts?Search=Type eq 2');
    // });
  }

  onTaxesLoaded(items: any[]): void {
    if (items?.length) {
      items.forEach(x => {
        x.name = `${x.name} (${x.rate}%)`
      })
    }
  }

  onUnitTypeChanged(e) {
    this.salesInfo.reset();
    // this.purchaseUnitSelect?.reset();
    console.log('onUnitTypeChanged', e);
  }

  unitValidator(error?: string) {
    return (control: UntypedFormControl) => {
      if (this.form?.controls?.unitTypeId?.value && !control.value) {
        return this.error(error || message.this_field_is_required);
      }
      return of(true);
    }
  }

  onBeforeSubmit = (payload) => {
    payload.saleDetails = this.constructObject(this.salesInfo.form.controls);
    payload.saleDetails.itemId = this.id;
    console.log('on before submit', payload)
  }

  onSetFormValues = data => {
    this.salesInfo.setValues(this.salesInfo.form.controls, data.saleDetails);
    console.log('on set form values', data);
  };

}
