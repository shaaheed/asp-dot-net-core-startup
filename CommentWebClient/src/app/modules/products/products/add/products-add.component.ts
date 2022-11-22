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

  @ViewChild('purchaseUnitSelect') purchaseUnitSelect: SelectControlComponent;
  @ViewChild('purchaseTaxSelect') purchaseTaxSelect: SelectControlComponent;
  @ViewChild('purchaseAccountSelect') purchaseAccountSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;

  @ViewChild('inventoryAccountSelect') inventoryAccountSelect: SelectControlComponent;

  @ViewChild('categoriesSelect') categoriesSelect: SelectControlComponent;

  @ViewChild('unitTypeSelect') unitTypeSelect: SelectControlComponent;

  currency;

  onSetFormValues = data => {
    console.log('on set form values', data);
  };

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

      // isSale: [true],
      
      // isPurchase: [true],
      // purchasePrice: [],
      // purchaseAccountId: [],
      // purchaseDescription: [],
      // purchaseTaxes: [],
      // purchaseUnitId: [null, [], [
      //   this.unitValidator().bind(this)
      // ]],
      // supplierId: [],

      // isInventory: [true],
      // stockQuantity: [],
      // lowStockQuantity: [],
      // inventoryAccountId: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.categoriesSelect.register((pagination, search) => {
      return this._httpService.get('products/categories');
    });

    this.unitTypeSelect.register((pagination, search) => {
      return this._httpService.get('units/types');
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
    this.purchaseUnitSelect?.reset();
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

  getUnitUrl() {
    const unitTypeId = this.form.controls.unitTypeId.value;
    let unitUrl = 'units';
    if (unitTypeId) {
      unitUrl += `?Filter=TypeId eq ${unitTypeId}`;
    }
    return unitUrl;
  }

}
