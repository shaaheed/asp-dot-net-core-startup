import { Component, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormGroup, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { forkJoin, of } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { forEachObj } from 'src/services/utilities.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ButtonSelectComponent } from 'src/app/shared/button-select/button-select.component';
import { AutocompleteComponent } from 'src/app/shared/autocomplete/autocomplete.component';
import { ValidatorService } from 'src/services/validator.service';
import { NzSelectComponent } from 'ng-zorro-antd/select';
import { CURRENCY } from '../../organizations/organization.service';

@Component({
  selector: 'app-invoices-add',
  templateUrl: './invoices-add.component.html',
  styleUrls: ['./invoices-add.component.scss']
})
export class InvoicesAddComponent extends FormComponent {

  apiUrl = 'invoices';
  contactApiUrl = 'contacts?Search=Type eq 1';
  objectName = 'invoice';
  contactTitle = 'customer';
  chooseAnotherTitle = 'choose.a.different.customer';

  subtotal: number = 0;
  products: any[] = [];
  units: any[] = [];

  @ViewChild('contactSelect') contactSelect: ButtonSelectComponent;
  @ViewChildren('autocomplete') autocomplete: QueryList<AutocompleteComponent>;
  @ViewChildren('unitSelects') unitSelects: QueryList<NzSelectComponent>;

  form: FormGroup;
  invoiceItemsFormArray: FormArray

  formItemStyle = { padding: 0 };
  adjustFormItemStyle = { padding: 0, display: 'flex', justifyContent: 'flex-end' };
  adjustFormControlStyle = { maxWidth: '170px' };
  currency;
  unitSuffix;

  onSetFormValues = data => {
    this.prepareForm(data);
  };
  onSetInvoiceNumber: () => string;

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
      number: [null, [], this.validator.required()],
      issueDate: [new Date(), [], this.validator.requiredDate()],
      paymentDueDate: [new Date(), [], this.validator.requiredDate()],
      contactId: [],
      productId: [],
      adjustmentText: ['Adjustment'],
      adjustmentAmount: [],
      items: this.fb.array([])
    });

    const requests = [
      this._httpService.get('products'),
      this._httpService.get('units')
    ];
    if (!this.onSetInvoiceNumber && this.isAddMode()) {
      requests.push(this._httpService.get('invoices/create-info'))
    }

    this.loading = true;
    this.subscribe(forkJoin(requests),
      (res: any) => {
        this.loading = false;
        if (res) {
          if (res[0].data?.items) {
            this.products = res[0].data.items;
          }
          if (res[1].data?.items) {
            this.units = res[1].data.items;
            this.setItemUnitIdDefaultValue(this.unitSelects.toArray());
          }

          let nextInvoiceNumber = null;
          if (!this.onSetInvoiceNumber && this.isAddMode() && res[2].data.nextInvoiceNumber) {
            nextInvoiceNumber = res[2].data.nextInvoiceNumber;
          }
          else if (this.onSetInvoiceNumber) {
            nextInvoiceNumber = this.onSetInvoiceNumber();
          }
          if (nextInvoiceNumber) {
            this.setValue('number', nextInvoiceNumber);
          }
        }
      },
      err => this.loading = false
    );

    if (this.isAddMode()) {
      setTimeout(() => this.addAnItem(), 0);
    }
  }

  ngAfterViewInit() {
    this.subscribe(this.autocomplete.changes, (autocompleteList: QueryList<AutocompleteComponent>) => {
      autocompleteList.forEach(autocomplete => {
        const index = autocomplete.name;
        this.subscribe(autocomplete.autocomplete.selectionChange, value => {
          const id = value.nzValue || "";
          const groups = this.form.get('items').get(index.toString()) as FormGroup;
          const item = autocomplete.options.filter(x => x.id == id)[0];
          if (item && groups) {
            groups.controls.unitId.setValue(item.salesUnit?.id);
            groups.controls.quantity.setValue(1);
            groups.controls.productId.setValue(id);
            groups.controls.unitPrice.setValue(item.salesPrice);
          }
        });
      });
    });

    this.subscribe(this.unitSelects.changes, (selects: QueryList<NzSelectComponent>) => {
      this.setItemUnitIdDefaultValue(selects.toArray());
    });

    if (this.contactSelect?.select) {
      this.contactSelect.select.register((pagination, search) => {
        return this._httpService.get(this.contactApiUrl);
      });
    }
  }

  searchProduct(autocomplete: AutocompleteComponent) {
    this.subscribe(this._httpService.get('products'),
      (success: any) => {
        if (success?.data?.items) {
          autocomplete.options = success.data.items.filter(x => x.name.includes(autocomplete.value));
        }
      }
    );
  }

  addAnItem() {
    this.createInvoiceItemFormGroup({});
    this.calculateInvoiceSubtotal();
  }

  productSelectOnChange(e) {
    const p = this.products.filter(x => x.id == e)[0];
    if (p) {
      p.quantity = p.quantity || 1;
      p.amount = p.quantity * p.price;
      this.createInvoiceItemFormGroup(p);
      this.calculateInvoiceSubtotal();
    }
  }

  deleteItemFromInvoice(index) {
    if ((this.form.get('items') as FormArray)?.length > 1) {
      const invoiceItemsFormArray = this.getInvoiceItemFormArray();
      if (invoiceItemsFormArray.controls && invoiceItemsFormArray.controls.length) {
        invoiceItemsFormArray.removeAt(index);
        this.calculateInvoiceSubtotal();
      }
    }
  }

  invoiceItemQuantityChanged(data) {
    this.calculateInvoiceItemAmount(data);
  }

  invoiceItemPriceChanged(data) {
    this.calculateInvoiceItemAmount(data);
  }

  private setItemUnitIdDefaultValue(selects: NzSelectComponent[]) {
    if (this.units.length && selects) {
      selects.forEach(select => {
        const index = (<any>select).elementRef.nativeElement.getAttribute('name');
        if (index != null && index != undefined) {
          const groups = this.form.get('items').get(index.toString()) as FormGroup;
          if (!groups.controls.unitId.value) {
            setTimeout(() => groups.controls.unitId.setValue(this.units[0].id), 0);
          }
        }
      });
    }
  }

  private prepareForm(data) {
    this.form.controls.items = this.fb.array([]);
    if (data.items && data.items.length) {
      data.items.forEach(x => {
        const o = {
          id: x.id,
          name: x.name,
          description: x.description,
          quantity: x.quantity,
          unitPrice: x.unitPrice,
          amount: x.total,
          productId: x.productId,
          unitId: x.unit?.id
        }
        this.createInvoiceItemFormGroup(o);
      });
    }
    this.calculateInvoiceSubtotal();
  }

  private calculateInvoiceItemAmount(data) {
    const quantity = Number(data.controls.quantity.value);
    const price = Number(data.controls.unitPrice.value);
    if (!isNaN(quantity) && !isNaN(price)) {
      const amount = quantity * price;
      data.controls.amount.setValue(amount);
    }
    this.calculateInvoiceSubtotal();
  }

  private calculateInvoiceSubtotal() {
    const invoiceItemsFormArray = this.getInvoiceItemFormArray();
    let subtotal = 0;
    forEachObj(invoiceItemsFormArray.controls, (k, v) => {
      const amount = Number(v.controls.amount.value);
      if (!isNaN(amount)) {
        subtotal += amount;
      }
    });
    this.subtotal = subtotal;
  }

  private createInvoiceItemFormGroup(data: any) {
    const formGroup = this.fb.group({
      name: [null, [], this.validator.required()],
      description: [],
      quantity: [null, [], this.validator.required()],
      unitPrice: [null, [], this.priceValidator.bind(this)],
      amount: [],
      productId: [],
      unitId: [],
      taxId: []
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const invoiceItemsFormArray = this.getInvoiceItemFormArray();
    invoiceItemsFormArray.push(formGroup);
  }

  private getInvoiceItemFormArray(): FormArray {
    return this.form.get("items") as FormArray;
  }

  private priceValidator(control: FormControl) {
    if (!control.value) {
      return this.error('please.give.a.price');
    }
    else if (isNaN(Number(control.value))) {
      return this.error('price.must.be.numeric');
    }
    return of(true);
  }

}
