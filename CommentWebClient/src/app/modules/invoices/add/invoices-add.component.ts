import { Component, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { forkJoin, of } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { forEachObj, clean } from 'src/services/utilities.service';
import { FormComponent } from 'src/app/shared/form.component';
import { InvoiceService } from '../services/invoice.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ButtonSelectComponent } from 'src/app/shared/button-select/button-select.component';
import { AutocompleteComponent } from 'src/app/shared/autocomplete/autocomplete.component';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-invoices-add',
  templateUrl: './invoices-add.component.html',
  styleUrls: ['./invoices-add.component.scss']
})
export class InvoicesAddComponent extends FormComponent {

  mode: string = 'add';
  loading: boolean = true;
  noData: boolean = false;
  apiUrl = 'invoices';
  cancelRoute = 'invoices';
  objectName = "invoice";

  subtotal: number = 0;

  products: any[] = [];
  units: any[] = [];

  @ViewChild('customerSelect') customerSelect: ButtonSelectComponent;
  @ViewChildren('autocomplete') autocomplete: QueryList<AutocompleteComponent>;

  form: FormGroup;
  invoiceItemsFormArray: FormArray

  formItemStyle = { padding: 0 };
  adjustFormItemStyle = { padding: 0, display: 'flex', justifyContent: 'flex-end' };
  adjustFormControlStyle = { maxWidth: '170px' };

  constructor(
    public fb: FormBuilder,
    private invoiceService: InvoiceService,
    private route: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  ngOnInit(): void {
    const requests = [
      this._httpService.get('products'),
      this._httpService.get('units'),
    ]
    this.subscribe(forkJoin(requests),
      (success: any) => {
        if (success) {
          if (success[0].data?.items) {
            this.products = success[0].data.items;
          }
          if (success[1].data?.items) {
            this.units = success[1].data.items;
          }
        }
      }
    );

    this.createForm({
      invoiceDate: [new Date(), [], this.invoiceDateValidator.bind(this)],
      paymentDue: [null, [], this.paymentDueValidator.bind(this)],
      customer: [],
      product: [],
      adjustmentText: ['Adjustment'],
      adjustmentAmount: [],
      items: this.fb.array([])
    });

    const snapshot = this.route.snapshot;
    const id = snapshot.params.id
    if (!id) {
      this.form.controls.invoiceDate.setValue(new Date());
      this.form.controls.paymentDue.setValue(new Date());
    }

    this.subscribe(this.invoiceService.get(id),
      (res: any) => {
        if (id) {
          this.prepareForm(res);
        }
        this.loading = false;
      },
      err => {
        this.loading = false;
      }
    );
    super.ngOnInit(snapshot);

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
          if (item) {
            groups.controls.quantity.setValue(1);
            groups.controls.productId.setValue(id);
            groups.controls.price.setValue(item.salesPrice);
            groups.controls.unit.setValue(item.salesUnit);
          }
        });
      });
    });

    if (this.customerSelect?.select) {
      this.customerSelect.select.register((pagination, search) => {
        return this._httpService.get('contacts?Search=Type eq 1');
      });
    }
  }

  submit() {
    const obj: any = this.constructObject(this.form.controls);
    let body: any = {
      invoiceDate: obj.invoiceDate,
      paymentDue: obj.paymentDue,
      customerId: obj.customer,
      items: obj.items.map(x => {
        return {
          name: x.name,
          description: x.description,
          quantity: x.quantity,
          unitPrice: x.price,
          price: x.amount,
          total: x.amount,
          subtotal: x.amount,
          productId: x.productId
        }
      })
    }
    body = clean(body);
    this.submitForm(
      {
        request: this.invoiceService.add(body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.created', x => this._messageService.success(x));
        }
      },
      {
        request: this.invoiceService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.updated', x => this._messageService.success(x));
        }
      }
    );
  }

  invoiceDateValidator(control: FormControl) {
    if (!control.value) {
      return this.error('select.date');
    }
    return of(true);
  }

  paymentDueValidator(control: FormControl) {
    if (!control.value) {
      return this.error('select.date');
    }
    return of(true);
  }

  cancel() {
    this._router.navigateByUrl(`invoices`);
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

  private prepareForm(data) {
    this.form.controls.invoiceDate.setValue(data.issueDate);
    this.form.controls.paymentDue.setValue(data.paymentDueDate);
    this.form.controls.customer.setValue(data.customer ? data.customer.id : null);
    this.form.controls.items = this.fb.array([]);
    if (data.items && data.items.length) {
      data.items.forEach(x => {
        const o = {
          id: x.id,
          name: x.name,
          description: x.description,
          quantity: x.quantity,
          price: x.unitPrice,
          amount: x.total,
          productId: x.productId
        }
        this.createInvoiceItemFormGroup(o);
      });
    }
    this.calculateInvoiceSubtotal();
  }

  private calculateInvoiceItemAmount(data) {
    const quantity = Number(data.controls.quantity.value);
    const price = Number(data.controls.price.value);
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
      price: [null, [], this.priceValidator.bind(this)],
      amount: [],
      productId: [],
      unit: [],
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
