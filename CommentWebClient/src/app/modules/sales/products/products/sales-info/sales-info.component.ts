import { Component, Input, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ValidatorService } from 'src/services/validator.service';
import { CURRENCY } from 'src/app/modules/organizations/organization.service';
import { AbstractControl, UntypedFormArray, UntypedFormControl } from '@angular/forms';
import { message } from 'src/constants/message';
import { of } from 'rxjs';
import { forEachObj } from 'src/services/utilities.service';

@Component({
  selector: 'app-products-sales-info',
  templateUrl: './sales-info.component.html',
  styleUrls: ['./sales-info.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ProductSalesInfoAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'products';
  objectName = "product";

  @Input() unitTypeId;

  @ViewChild('currencySelect') currencySelect: SelectControlComponent;
  @ViewChild('currenciesSelect') currenciesSelect: SelectControlComponent;
  @ViewChild('unitSelect') unitSelect: SelectControlComponent;
  @ViewChild('taxSelect') taxSelect: SelectControlComponent;
  @ViewChild('accountSelect') accountSelect: SelectControlComponent;

  currency;
  currencies = ['BDT', 'USD', 'AUD', 'EUR'];
  pricesList = [
    { name: 'Wholesale', price: 10 },
    { name: 'Offer', price: 9 },
  ]
  priceInputSuffix: string = "";
  priceInputPrefix: string = "BDT";

  formItemStyle = { padding: 0 };

  onSetFormValues = data => {
    console.log('on set form values', data);
  };

  constructor(
    private route: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  ngOnInit(): void {
    const data = this.route.snapshot.data;
    if (data?.componentAccessor) {
      data.componentAccessor(this);
    }
    super.ngOnInit(this.route.snapshot);

    this.currency = CURRENCY;
    this.createForm({
      id: [],
      currencyId: [],
      currencies: [],
      price: [],
      accountId: [],
      description: [],
      taxId: [],
      unitId: [null, [], [
        this.unitValidator().bind(this)
      ]],
      prices: this.fb.array([])
    });

    this.prepareForm({ prices: this.pricesList })
  }

  ngAfterViewInit() {
    this.currencySelect.register((pagination, search) => {
      return this._httpService.get('systems/currencies');
    });

    this.currenciesSelect.register((pagination, search) => {
      return this._httpService.get('systems/currencies');
    });

    this.unitSelect.register((pagination, search) => {
      return this._httpService.get(this.getUnitUrl());
    });

    this.taxSelect.register((pagination, search) => {
      return this._httpService.get('taxes');
    });
  }

  onTaxesLoaded(items: any[]): void {
    if (items?.length) {
      items.forEach(x => {
        x.name = `${x.name} (${x.rate}%)`
      })
    }
  }

  onUnitSelected(e) {
    if (e.name) {
      this.priceInputSuffix = `/ ${e.name}`;
    }
  }

  reset() {
    this.unitSelect?.reset();
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
    let unitUrl = 'systems/units';
    if (this.unitTypeId) {
      unitUrl += `?Filter=TypeId eq ${this.unitTypeId}`;
    }
    return unitUrl;
  }

  log(e) {
    console.log(e)
  }

  private prepareForm(data) {
    this.form.controls.prices = this.fb.array([]);
    if (data?.prices?.length) {
      data.prices.forEach(x => {
        const o = {
          id: x.id,
          currencyId: x.currencyId,
          price: x.price,
          name: x.name
        }
        this.createPricesFormGroup(o);
      });
    }
  }

  private createPricesFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      currencyId: [],
      name: [],
      price: [],
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const list = this.getPricesFormArray();
    list.push(formGroup);
  }

  private getPricesFormArray(): UntypedFormArray {
    return this.form.get("prices") as UntypedFormArray;
  }

}
