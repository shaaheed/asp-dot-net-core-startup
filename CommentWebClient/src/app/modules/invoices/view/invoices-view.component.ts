import { Location } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/base.component';
import { TableConfig } from 'src/app/shared/table2/table.config';
import { Column } from 'src/services/column.service';
import { CURRENCY } from '../../organizations/organization.service';
import { PaymentsAddModalComponent } from '../payments-add-modal/payments-add-modal.component';

@Component({
  selector: 'app-invoices-view',
  templateUrl: './invoices-view.component.html',
  styleUrls: ['./invoices-view.component.scss']
})
export class InvoicesViewComponent extends BaseComponent {

  loading: boolean = false;
  model: any = {};
  subtotal: any = "-";
  total: any = "-";
  visible: boolean = true;
  showCustomer: boolean = false;
  showPaymentModal: boolean = false;
  paymentModalData: any = {}
  invoiceId;
  currency = '';

  @ViewChild('paymentModal') paymentModal: PaymentsAddModalComponent;

  paymentTableConfig = <TableConfig>{
    getFetchApiUrl: x => `invoices/${this.invoiceId}/payments`,
    pageTitle: 'payments',
    getDeleteApiUrl: x => `invoices/${this.invoiceId}/payments/${x.id}`,
    onClickButton: source => {
      console.log(source);
      if (source?.label == 'new' && this.model?.amountDue > 0) {
        this.payment();
      }
    },
    tableColumns: [
      Column.column('number', x => x.number),
      Column.date('date', x => x.paymentDate),
      {
        title: 'payment.amount',
        getCellData: x => `${this.currency} ${x.amount}`,
        tdClass: 'fit-cell ta-right'
      }
    ],
    headerStyle: {
      padding: '10px 0'
    }
  }

  constructor(
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    super();
  }

  ngOnInit() {
    this.currency = CURRENCY;
    const snapshot = this.activatedRoute.snapshot;
    this.invoiceId = snapshot.params.id;
    this.paymentModalData.invoiceId = this.invoiceId;
    this.get(this.invoiceId);
  }

  ngAfterViewInit() {
    this.setPaymentModalApiUrl();
  }

  refresh() {
    this.get(this.invoiceId);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this._httpService.get(`invoices/${id}`),
      (res: any) => {
        this.loading = false;
        if (res) {
          this.model = res.data;
          if (this.model?.items) {
            this.subtotal = this.model.items.reduce((a, c) => a + c.subtotal, 0);
            this.total = this.model.items.reduce((a, c) => a + c.total, 0);
            this.paymentModalData.invoiceTotal = this.total;
          }
          this.paymentModalData = {
            title: this._translate.instant('add.payment.for.invoice.x0', { x0: this.model.number }),
            mode: 'add',
            amount: this.model.amountDue,
            currency: this.currency
          }
          this.setPaymentModalApiUrl();
        }
      },
      err => {
        this.loading = false;
      }
    );
  }

  setPaymentModalApiUrl() {
    if (this.paymentModal) {
      this.paymentModal.buildApiUrl = data => {
        return `invoices/${this.invoiceId}/payments`;
      }
    }
  }

  delete(e) {
    const deleteModal = this._modalService.confirm({
      nzTitle: 'Confirm',
      nzContent: `Do you want to delete?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        // deleteModal.getInstance().nzOkLoading = true;
        this.subscribe(/*this.invoiceService.delete(e.id)*/null,
          res => {
            // deleteModal.getInstance().nzOkLoading = false;
            this._messageService.success('Successfully deleted');
            // this.get();
          },
          err => {
            // deleteModal.getInstance().nzOkLoading = false;
            console.log('err', err)
          }
        );
      }
    });
  }

  showCustomerDrawer(customer: any) {
    this.showCustomer = !this.showCustomer
  }

  closeCustomerDrawer() {
    this.showCustomer = false;
  }

  payment() {
    this.showPaymentModal = true;
  }

  edit() {
    this._router.navigateByUrl(`invoices/${this.invoiceId}/edit`);
  }

  add() {
    this._router.navigateByUrl(`invoices/create`);
  }

  cancel() {
    this.location.back();
  }

  print() {
    this.subscribe(this._httpService.get(`invoices/${this.invoiceId}/print`),
      (res: any) => {
        if (res?.data) {
          const invoicePrintSectionId = 'invoice-print-section';
          const oldPrintSection = document.getElementById(invoicePrintSectionId);
          if (oldPrintSection) {
            oldPrintSection.remove();
          }
          const div = document.createElement('div');
          div.setAttribute('id', invoicePrintSectionId);
          div.innerHTML = res.data;
          document.getElementsByTagName('html')[0].appendChild(div);
          window.print();
          div.remove();
        }
      }
    );
  }

}
