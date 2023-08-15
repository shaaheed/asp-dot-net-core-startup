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
import { ProductPurchaseInfoAddComponent } from '../purchase-info/purchase-info.component';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html'
})
export class ProductsAddComponent extends FormComponent {

  data: any = null;
  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'products';
  objectName = "product";

  @ViewChild('salesInfo') salesInfo: ProductSalesInfoAddComponent;
  @ViewChild('purchaseInfo') purchaseInfo: ProductPurchaseInfoAddComponent;
  @ViewChild('categoriesSelect') categoriesSelect: SelectControlComponent;
  @ViewChild('unitTypeSelect') unitTypeSelect: SelectControlComponent;

  currency;

  constructor(
    private activatedRoute: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
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
  }

  onUnitTypeChanged(e) {
    this.salesInfo?.reset();
    this.purchaseInfo?.reset();
  }

  unitValidator(error?: string) {
    return (control: UntypedFormControl) => {
      if (this.form?.controls?.unitTypeId?.value && !control.value) {
        return this.error(error || message.this_field_is_required);
      }
      return of(true);
    }
  }

  onPurchaseDetailsUpdated(e) {
    console.log('onPurchaseDetailsUpdated', e);
    this.data.purchaseDetails = e;
  }

  onBeforeSubmit = (payload) => {
    payload.saleDetails = this.constructObject(this.salesInfo.form.controls);
    payload.saleDetails.itemId = this.id;
    if (this.purchaseInfo) {
      payload.purchaseDetails = this.constructObject(this.purchaseInfo.form.controls);
      payload.purchaseDetails.itemId = this.id;
    }
    console.log('on before submit', payload)
  }

  onGetData = data => {
    setTimeout(() => this.data = data, 0);
  };

}
