import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from 'src/app/shared/form.component';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-payments-add-modal',
  templateUrl: './payments-add-modal.component.html'
})
export class PaymentsAddModalComponent extends FormComponent {

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
    private route: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  ngOnInit(): void {

    this.createForm({
      number: [null, [], this.validator.required()],
      paymentDate: [new Date(), [], this.validator.requiredDate()],
      amount: [null, [], this.validator.amount(this.data.invoiceTotal)],
      paymentMethod: [],
      paymentAccount: [],
      memo: []
    });

    if (this.data.mode == 'edit') {
      this.markModeAsEdit();
    }
    else {
      this.data.mode == 'add';
      this.markModeAsAdd();
      this.subscribe(this._httpService.get(`payments/create-info`),
        (res: any) => {
          if (res?.data?.nextPaymentNumber) {
            this.setValue('number', res.data.nextPaymentNumber);
          }
        }
      );
    }

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

  handleCancel() {
    this.show = false;
    this.showChange.emit(false);
  }

  private prepareForm(data) {
    if (data) {
      this.form.controls.paymentDate.setValue(data.issueDate);
      this.form.controls.amount.setValue(data.amount);
    }
  }

}
