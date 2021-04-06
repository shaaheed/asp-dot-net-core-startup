import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from 'src/app/shared/form.component';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-payments-add-modal',
  templateUrl: './payments-add-modal.component.html'
})
export class PaymentsAddModalComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  objectName = "payment";

  @Input() show = false;
  @Output() showChange = new EventEmitter<boolean>();
  paymentMethods: any[] = [];

  @ViewChild(SelectControlComponent) paymentMethodSelect: SelectControlComponent;
  registerPaymentMethodSelect = (pagination, search) => {
    return this._httpService.get('payments/methods');
  }

  private _data: any = {};

  @Input() set data(data: any) {
    this._data = data;
    if (this.form) {
      this.form.controls.amount.setValue(this.data.amount || 0);
    }
  }

  get data() {
    return this._data;
  }

  constructor(
    private route: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    if (this.data.mode == 'edit') {
      this.markModeAsEdit();
    }
    else {
      this.data.mode == 'add';
      this.markModeAsAdd()
    }
    this.createForm({
      paymentDate: [new Date(), [], this.paymentDateValidator.bind(this)],
      amount: [null, [], this.paymentAmountValidator.bind(this)],
      paymentMethod: [],
      paymentAccount: [],
      memo: []
    });

    this.form.controls.paymentMethod.setValue(2);
    const snapshot = this.route.snapshot;
    const id = snapshot.params.id
    if (id) {
      //requests.push();
    }
    else {
      this.form.controls.paymentDate.setValue(new Date());
    }
  }

  // ngAfterViewInit() {
  //   this.paymentMethodSelect.register((pagination, search) => {
  //     return this._httpService.get('payments/methods');
  //   });
  // }

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
