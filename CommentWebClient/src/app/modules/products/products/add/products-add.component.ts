import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html'
})
export class ProductsAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'products';
  objectName = "product";

  @ViewChild('salesUnitSelect') salesUnitSelect: SelectControlComponent;
  @ViewChild('salesTaxSelect') salesTaxSelect: SelectControlComponent;
  @ViewChild('salesAccountSelect') salesAccountSelect: SelectControlComponent;

  @ViewChild('purchaseUnitSelect') purchaseUnitSelect: SelectControlComponent;
  @ViewChild('purchaseTaxSelect') purchaseTaxSelect: SelectControlComponent;
  @ViewChild('purchaseAccountSelect') purchaseAccountSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;

  @ViewChild('inventoryAccountSelect') inventoryAccountSelect: SelectControlComponent;

  @ViewChild('categoriesSelect') categoriesSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], [
        this.validator.required().bind(this),
        this.validator.min(2).bind(this)
      ]],
      categories: [],
      description: [],

      isSale: [true],
      salesPrice: [],
      salesAccountId: [],
      salesDescription: [],
      salesTaxes: [],
      salesUnitId: [],

      isPurchase: [true],
      purchasePrice: [],
      purchaseAccountId: [],
      purchaseDescription: [],
      purchaseTaxes: [],
      purchaseUnitId: [],
      supplierId: [],

      isInventory: [true],
      stockQuantity: [],
      lowStockQuantity: [],
      inventoryAccountId: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.categoriesSelect.register((pagination, search) => {
      return this._httpService.get('products/categories');
    });

    this.salesUnitSelect.register((pagination, search) => {
      return this._httpService.get('units');
    });
    this.salesTaxSelect.register((pagination, search) => {
      return this._httpService.get('taxes');
    });

    this.purchaseUnitSelect.register((pagination, search) => {
      return this._httpService.get('units');
    });
    this.purchaseTaxSelect.register((pagination, search) => {
      return this._httpService.get('taxes');
    });
    this.supplierSelect.register((pagination, search) => {
      return this._httpService.get('contacts?Search=Type eq 2');
    });
  }

}
