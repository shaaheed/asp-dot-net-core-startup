import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { clean } from 'src/services/utilities.service';
import { FormComponent } from 'src/app/shared/form.component';
import { InvoiceService } from '../services/invoice.service';
import { PaymentService } from '../services/payment.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-payments-add-modal',
  templateUrl: './payments-add-modal.component.html'
})
export class PaymentsAddModalComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'payments';
  cancelRoute = 'payments';
  objectName = "payment";

  @Input() show = false;
  @Output() showChange = new EventEmitter<boolean>();
  @Input() data: any = {};

  form: FormGroup;
  dateFormat: string = "dd-MM-yyyy";
  paymentMethods: any[] = [];

  @ViewChild('paymentMethodSelect') paymentMethodSelect: SelectControlComponent;

  constructor(
    public fb: FormBuilder,
    private route: ActivatedRoute,
    private invoiceService: InvoiceService,
    private paymentService: PaymentService
  ) {
    super();
  }

  ngOnInit(): void {

    if (this.data.mode != 'add') {
      this.markModeAsEdit();
    }
    else
    {
      this.data.mode == 'add';
      this.markModeAsAdd()
    }

    this.form = this.fb.group({
      paymentDate: [new Date(), [], this.paymentDateValidator.bind(this)],
      amount: [null, [], this.paymentAmountValidator.bind(this)],
      paymentMethod: [],
      paymentAccount: [],
      memo: []
    });

    this.form.controls.paymentMethod.setValue(2);
    this.form.controls.amount.setValue(this.data.invoiceTotal);

    const snapshot = this.route.snapshot;
    const id = snapshot.params.id
    let requests = [
      this.paymentService.getPaymentMethods()
    ]
    if (id) {
      //requests.push();
    }
    else {
      this.form.controls.paymentDate.setValue(new Date());
    }

    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.paymentMethods = res[0];
        this.loading = false;
      },
      err => {
        this.loading = false;
      }
    );
    //super.ngOnInit(snapshot);
  }

  ngAfterViewInit() {
    // this.paymentMethodSelect.register((pagination, search) => {
    //   return this._httpService.get('payments/methods');
    // });
  }

  submit() {
    let body: any = this.constructObject(this.form.controls);
    body.invoiceId = this.data.invoiceId;
    body.paymentMethodId = body.paymentMethod;
    body = clean(body);
    this.submitForm(
      {
        request: this.invoiceService.addPayment(this.data.invoiceId, body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.created', x => this._messageService.success(x));
        }
      },
      {
        request: this.invoiceService.editPayment(this.id, body),
        succeed: res => {
          this.cancel();
          this.translate('successfully.updated', x => this._messageService.success(x));
        }
      }
    );
  }

  paymentDateValidator(control: FormControl) {
    if (!control.value) {
      return this.error('select.date');
    }
    return of(true);
  }

  paymentAmountValidator(control: FormControl) {
    if (!control.value) {
      return this.error('amount.is.required');
    }
    else if (isNaN(Number(control.value))) {
      return this.error('amount.must.be.numeric');
    }
    else if (Number(control.value) <= 0) {
      return this.error('amount.must.be.positive');
    }
    else if (Number(control.value) > this.data.invoiceTotal) {
      return this.error('amount.exceeds');
    }
    return of(true);
  }

  handleCancel() {
    this.show = false;
    this.showChange.emit(false);
  }

  cancel() {
    this._router.navigateByUrl(`invoices`);
  }

  paymentMethodSelectOnChange(e) {

  }

  paymentAccountSelectOnChange(e) {

  }

  private prepareForm(data) {
    if (data) {
      this.form.controls.paymentDate.setValue(data.issueDate);
      this.form.controls.amount.setValue(data.amount);
    }
  }

}
