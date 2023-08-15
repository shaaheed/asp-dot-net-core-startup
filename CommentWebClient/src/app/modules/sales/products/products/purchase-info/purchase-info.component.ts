import { Component, Input, Output, ViewChild, ViewEncapsulation, EventEmitter } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ValidatorService } from 'src/services/validator.service';
import { CURRENCY } from 'src/app/modules/organizations/organization.service';
import { AbstractControl, UntypedFormArray, UntypedFormControl } from '@angular/forms';
import { message } from 'src/constants/message';
import { of } from 'rxjs';
import { buildFilter, forEachObj } from 'src/services/utilities.service';

@Component({
  selector: 'app-products-purchase-info',
  templateUrl: './purchase-info.component.html',
  styleUrls: ['./purchase-info.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ProductPurchaseInfoAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  objectName = "product";

  @Input() unitTypeId;
  @Input() data;
  @Output() updated = new EventEmitter();

  @ViewChild('currencySelect') currencySelect: SelectControlComponent;
  @ViewChild('currenciesSelect') currenciesSelect: SelectControlComponent;
  @ViewChild('unitSelect') unitSelect: SelectControlComponent;
  @ViewChild('accountSelect') accountSelect: SelectControlComponent;

  currency;
  suppliers = [
    { supplier: { name: 'Wholesale' }, isPreferred: true, price: 10 },
    { supplier: { name: 'Offer' }, isPreferred: false, price: 9 },
  ]

  formItemStyle = { padding: 0 };

  priceInputSuffix: string = "";

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
    this.currency = CURRENCY;
    this.createForm({
      id: [],
      currencies: [],
      currencyId: [],
      price: [],
      accountId: [],
      description: [],
      unitId: [null, [], [
        this.unitValidator().bind(this)
      ]],
      suppliers: this.fb.array([])
    });
    super.ngOnInit(this.route.snapshot);

    this.data.suppliers = this.suppliers;
    this.prepareForm(this.data);
  }

  ngAfterViewInit() {
    this.unitSelect.register((pagination, search) => {
      return this._httpService.get(this.getUnitUrl());
    });

    this.currencySelect.register((pagination, search) => {
      return this._httpService.get(`systems/currencies`, pagination, buildFilter('Name', 'like', search));
    });

    this.currenciesSelect.register((pagination, search) => {
      return this._httpService.get('systems/currencies', pagination, buildFilter('Name', 'like', search));
    });

    // this.supplierSelect.register((pagination, search) => {
    //   return this._httpService.get('contacts?Search=Type eq 2');
    // });
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

  ngOnDestroy() {
    super.ngOnDestroy();
    this.data = this.constructObject(this.form.controls);
    this.updated.emit(this.data);
  }

  private prepareForm(data) {
    this.form.controls.suppliers = this.fb.array([]);
    if (data?.suppliers?.length) {
      data.suppliers.forEach(x => {
        const o = {
          id: x.id,
          supplierId: x.supplier.id,
          supplierName: x.supplier.name,
          isPreferred: x.isPreferred
        }
        this.createSuppliersFormGroup(o);
      });
    }
    this.setValues(this.form.controls, data);
  }

  private createSuppliersFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      supplierId: [],
      supplierName: [],
      isPreferred: []
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const list = this.getSuppliersFormArray();
    list.push(formGroup);
  }

  private getSuppliersFormArray(): UntypedFormArray {
    return this.form.get("suppliers") as UntypedFormArray;
  }

}
