import { Component, ElementRef, HostListener, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, UntypedFormArray, AbstractControl } from '@angular/forms';
import { forkJoin, of } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { beep, forEachObj } from 'src/services/utilities.service';
import { FormComponent } from 'src/app/shared/form.component';
import { AutocompleteComponent } from 'src/app/shared/autocomplete/autocomplete.component';
import { ValidatorService } from 'src/services/validator.service';
import { NzSelectComponent } from 'ng-zorro-antd/select';
import { CURRENCY } from '../../organizations/organization.service';
import { NzAutocompleteOptionComponent } from 'ng-zorro-antd/auto-complete';

@Component({
  selector: 'app-invoices-add',
  templateUrl: './invoices-add.component.html',
  styleUrls: ['./invoices-add.component.scss']
})
export class InvoicesAddComponent extends FormComponent {

  apiUrl = 'invoices';
  createInfoUrl = 'invoices/create-info';
  contactApiUrl = 'contacts?Search=Type eq 1';
  objectName = 'invoice';
  contactTitle = 'customer';
  chooseAnotherTitle = 'choose.a.different.customer';
  dateLabel = 'invoice.date';

  subtotal: number = 0;
  grandtotal: number = 0;
  products: any[] = [];
  globalSearchedProducts: any[] = [];
  searchedContacts: any[] = [];
  units: any[] = [];

  @ViewChild('contactAutocomplete') contactAutocomplete: AutocompleteComponent;
  @ViewChild('globalInput') globalInput: ElementRef;
  @ViewChildren('unitSelects') unitSelects: QueryList<NzSelectComponent>;

  textAlignRightStyle = { textAlign: 'right', paddingRight: '5px' };
  formItemStyle = { padding: 0 };
  adjustFormItemStyle = { padding: 0, display: 'flex', justifyContent: 'flex-end' };
  adjustFormControlStyle = { maxWidth: '170px' };
  currency;
  unitSuffix;

  private lastGlobalProductSearchSelection: any = null

  onSetFormValues = data => {
    this.prepareForm(data);
  };

  getNextNumber: (data: any) => string;

  onGetData = (data: any) => {
    if (this.isEditMode() && this.contactAutocomplete && data) {
      this.searchedContacts = [data.contact];
      this.contactAutocomplete.inputValue = data.contact.displayName;
      // this.contactAutocomplete.autocomplete.setActiveItem(0);
      // this.contactSelect.select.value = data.customer.id;
      // this.contactSelect.select.items = [data.customer];
    }
  }

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
    if (this.isAddMode()) {
      requests.push(this._httpService.get(this.createInfoUrl))
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
            this.setLineItemUnitIdDefaultValue(this.unitSelects.toArray());
          }
          if (this.isAddMode()) {
            let nextNumber = null;
            if (!this.getNextNumber && res[2].data.nextInvoiceNumber) {
              nextNumber = res[2].data.nextInvoiceNumber;
            }
            else if (this.getNextNumber) {
              nextNumber = this.getNextNumber(res[2].data);
            }
            if (nextNumber) {
              this.setValue('number', nextNumber);
            }
          }
        }
      },
      err => this.loading = false
    );

    if (this.isAddMode()) {
      setTimeout(() => this.addLineItem(), 0);
    }
  }

  @HostListener('window:keyup', ['$event'])
  onKeyup(event: any) {
    console.log('keyup..', event);
  }

  ngAfterViewInit() {
    // const globalProductSearchINput = this.globalInput.nativeElement as HTMLInputElement;
    // globalProductSearchINput.focus();

    this.subscribe(this.unitSelects.changes, (selects: QueryList<NzSelectComponent>) => {
      this.setLineItemUnitIdDefaultValue(selects.toArray());
    });
  }

  onContactSearchTermChanged(searchTerm: string) {
    this.searchContacts(searchTerm, items => this.searchedContacts = items);
  }

  onContactSelectionChanged(option: NzAutocompleteOptionComponent) {
    const contactId = option.nzValue || "";
    const contact = this.searchedContacts.filter(x => x.id == contactId)[0];
  }

  addLineItem(item = {}) {
    this.createLineItemFormGroup(item);
    this.calculateInvoiceTotal();
  }

  deleteLineItem(index) {
    const lineItems = this.getLineItemsFormArray();
    if (lineItems.length) {
      lineItems.removeAt(index);
      if (!lineItems.length) {
        this.addLineItem();
      }
      this.calculateInvoiceTotal();
    }
  }

  lineItemQuantityChanged(data) {
    this.calculateLineItemAmount(data);
  }

  lineItemPriceChanged(data) {
    this.calculateLineItemAmount(data);
  }

  onLineItemSearchTermChanged(searchTerm: string, autocomplete: AutocompleteComponent) {
    this.searchProducts(searchTerm, items => autocomplete.options = items);
  }

  onLineItemSelectionChanged(item: any, formGroup: UntypedFormGroup) {
    if (item) {
      // find product to invoice line items
      const newProductId = item.id;
      const lineItem = this.findLineItemByProductId(newProductId);
      if (lineItem) {
        this.addLineItemQuantity(lineItem);
      }
      else {
        const oldProductId = formGroup.controls.productId.value;
        formGroup.controls.productId.setValue(newProductId);
        let quantity = (formGroup.controls.quantity.value || 0) * 1;
        if (oldProductId == newProductId) {
          quantity += 1;
        }
        else {
          quantity = 1;
        }
        formGroup.controls.quantity.setValue(quantity);
        formGroup.controls.unitId.setValue(item.salesUnit?.id);
        formGroup.controls.unitPrice.setValue(item.salesPrice);
      }
    }
  }

  onGlobalProductSearchTermChanged(searchTerm: string) {
    this.lastGlobalProductSearchSelection = null;
    this.searchProducts(searchTerm, items => this.globalSearchedProducts = items);
  }

  onGlobalProductSelectionChanged(option: NzAutocompleteOptionComponent, input: HTMLInputElement) {
    this.focusAndSelectInput(input);
    const productId = option.nzValue || "";
    this.lastGlobalProductSearchSelection = this.globalSearchedProducts.filter(x => x.id == productId)[0];
  }

  onGlobalSearchEnterKeyup(input: HTMLInputElement) {
    this.focusAndSelectInput(input);
    if (this.lastGlobalProductSearchSelection) {
      this.addGlobalSearchProductInInvoice(this.lastGlobalProductSearchSelection.id);
      beep();
    }
  }

  onFormKeyup(event: KeyboardEvent) {
    this.log('onFormKeyup', event);
  }

  private addGlobalSearchProductInInvoice(productId: string) {
    const item = this.globalSearchedProducts.filter(x => x.id == productId)[0];
    if (item) {
      this.lastGlobalProductSearchSelection = item;
      const lineItems = this.getLineItemsFormArray();
      if (lineItems) {
        if (lineItems.length == 1 && this.isEmptyLineItem(lineItems.controls[0] as UntypedFormGroup)) {
          lineItems.removeAt(0);
        }
        const lineItem = this.findLineItemByProductId(productId);
        if (lineItem) {
          this.addLineItemQuantity(lineItem);
        }
        else {
          const _item = this.cloneProduct(item);
          this.addLineItem(_item);
        }
      }
    }
  }

  private setLineItemUnitIdDefaultValue(selects: NzSelectComponent[]) {
    if (this.units.length && selects) {
      selects.forEach(select => {
        const index = (<any>select).elementRef.nativeElement.getAttribute('name');
        if (index != null && index != undefined) {
          const groups = this.form.get('items').get(index.toString()) as UntypedFormGroup;
          if (!groups.controls.unitId.value) {
            setTimeout(() => groups.controls.unitId.setValue(this.units[0].id), 0);
          }
        }
      });
    }
  }

  private prepareForm(data) {
    this.form.controls.items = this.fb.array([]);
    if (data?.contact) {
      this.form.controls.contactId.setValue(data.contact.id);
    }
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
        this.createLineItemFormGroup(o);
      });
    }
    this.calculateInvoiceTotal();
  }

  private calculateLineItemAmount(data) {
    const quantity = Number(data.controls.quantity.value);
    const price = Number(data.controls.unitPrice.value);
    if (!isNaN(quantity) && !isNaN(price)) {
      const amount = quantity * price;
      data.controls.amount.setValue(amount);
    }
    this.calculateInvoiceTotal();
  }

  private calculateInvoiceTotal() {
    const lineItems = this.getLineItemsFormArray();
    let subtotal = 0;
    forEachObj(lineItems.controls, (k, v) => {
      const amount = Number(v.controls.amount.value);
      if (!isNaN(amount)) {
        subtotal += amount;
      }
    });
    this.subtotal = subtotal;
    this.grandtotal = this.subtotal;
    const adjustmentAmount = this.form.controls.adjustmentAmount.value;
    if (!isNaN(adjustmentAmount)) {
      this.grandtotal = this.grandtotal + adjustmentAmount;
    }
  }

  private createLineItemFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
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
    const lineItems = this.getLineItemsFormArray();
    lineItems.push(formGroup);
  }

  private getLineItemsFormArray(): UntypedFormArray {
    return this.form.get("items") as UntypedFormArray;
  }

  private isEmptyLineItem(lineItem: UntypedFormGroup): boolean {
    let isEmpty = true;
    ['name', 'quantity', 'unitPrice'].forEach(key => {
      isEmpty &&= !lineItem.controls[key].value;
    });
    return isEmpty;
  }

  private findLineItemByProductId(productId: string): UntypedFormGroup {
    const lineItems = this.getLineItemsFormArray();
    return lineItems.controls.filter((formGroup: UntypedFormGroup) => formGroup.controls.productId.value == productId)[0] as UntypedFormGroup;
  }

  private addLineItemQuantity(lineItem: UntypedFormGroup, quantity: number = 1) {
    if (lineItem) {
      const oldQuantity = (lineItem.controls.quantity.value || 0) * 1;
      lineItem.controls.quantity.setValue(oldQuantity + quantity);
    }
  }

  private searchProducts(searchTerm: string, onComplete: (products: any[]) => void): void {
    if (onComplete) {
      let url = `products`;
      if (searchTerm) {
        url += `?filter=Name like "${searchTerm}" or Barcode like "${searchTerm}"`
      }
      this.callApi(url, onComplete);
    }
  }

  private searchContacts(searchTerm: string, onComplete: (contacts: any[]) => void): void {
    if (onComplete) {
      let url = 'contacts?filter=';
      if (this.contactTitle == 'customer') {
        url += 'Type eq 1';
      }
      else {
        url += 'Type eq 2';
      }
      if (searchTerm) {
        url += ` and (DisplayName like "${searchTerm}" or Mobile like "${searchTerm}" or Email like "${searchTerm}")`;
      }
      this.callApi(url, onComplete);
    }
  }

  private priceValidator(control: UntypedFormControl) {
    if (!control.value) {
      return this.error('please.give.a.price');
    }
    else if (isNaN(Number(control.value))) {
      return this.error('price.must.be.numeric');
    }
    return of(true);
  }

  private cloneProduct(product: any, quantity = null): any {
    let qty = 1;
    if (quantity !== null && quantity !== undefined) {
      qty = quantity * 1;
    }
    const price = (product.salesPrice || 0) * 1;
    return {
      name: product.name,
      quantity: 1,
      productId: product.id,
      unitPrice: price,
      unitId: product.salesUnit?.id,
      amount: qty * price
    }
  }

  private focusAndSelectInput(input: HTMLInputElement) {
    input.select();
    input.setSelectionRange(0, input.value.length);
    input.focus();
  }

  private callApi(url: string, onComplete: (items: any[]) => void): void {
    if (onComplete) {
      this.subscribe(this._httpService.get(url),
        (success: any) => {
          if (success?.data?.items) {
            onComplete(success.data.items);
          }
        }
      );
    }
  }

}
