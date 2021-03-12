import { Component, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html'
})
export class ProductsAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  url = 'products';
  cancelRoute = 'products';
  addTitle = 'create.a.x0|{"x0":"product"}';
  editTitle = 'update.a.x0|{"x0":"product"}';

  @ViewChild('salesUnitSelect') salesUnitSelect: SelectControlComponent;
  @ViewChild('salesTaxSelect') salesTaxSelect: SelectControlComponent;
  @ViewChild('salesAccountSelect') salesAccountSelect: SelectControlComponent;
  
  @ViewChild('purchaseUnitSelect') purchaseUnitSelect: SelectControlComponent;
  @ViewChild('purchaseTaxSelect') purchaseTaxSelect: SelectControlComponent;
  @ViewChild('purchaseAccountSelect') purchaseAccountSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  
  @ViewChild('inventoryAccountSelect') inventoryAccountSelect: SelectControlComponent;

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], this.requiredValidator.bind(this)],
      category: [],
      description: [],
      isSale: [],
      salesUnitPrice: [],
      salesAccount: [],
      salesDescription: [],
      salesTax: [],
      salesUnit: [],
      isPurchase: [],
      purchaseUnitPrice: [],
      purchaseAccount: [],
      purchaseDescription: [],
      purchaseTax: [],
      purchaseUnit: [],
      supplier: [],
      isInventory: [],
      initialQuantity: [],
      lowStockAlertQuantity: [],
      inventoryAccount: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {

    this.salesUnitSelect.register((pagination, search) => {
      return of({
        data: {
          items: [
            { id: 1, name: 'কেজি' },
            { id: 2, name: 'গ্রাম' }
          ]
        }
      });
    }).fetch();

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
}
