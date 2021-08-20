import { Location } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/base.component';
import { TableComponent } from 'src/app/shared/table2/table.component';
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

  apiUrl: string = "invoices";
  objectName: string = "invoice";
  contactTitle: string = "customer";
  loading: boolean = false;
  model: any = {};
  subtotal: any = "-";
  total: any = "-";
  visible: boolean = true;
  showCustomer: boolean = false;
  showPaymentModal: boolean = false;
  paymentModalData: any = {}
  objectId;
  currency = "";
  contact: any;
  onGetData: (data: any) => void;

  @ViewChild('paymentModal') paymentModal: PaymentsAddModalComponent;
  @ViewChild('paymentTable') paymentTable: TableComponent;

  paymentTableConfig = <TableConfig>{
    getFetchApiUrl: x => `${this.apiUrl}/${this.objectId}/payments`,
    pageTitle: 'payments',
    getDeleteApiUrl: x => `${this.apiUrl}/${this.objectId}/payments/${x.id}`,
    onRowDeleted: data => {
      // on successful delete
      this.refresh(false);
    },
    onClickButton: source => {
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
    },
    boxStyle: {
      boxShadow: 'none'
    }
  }

  constructor(
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    const data = snapshot.data;
    if (data?.componentAccessor) {
      data.componentAccessor(this);
    }
    this.currency = CURRENCY;
    this.objectId = snapshot.params.id;
    this.paymentModalData.invoiceId = this.objectId;
    this.get(this.objectId);
  }

  ngAfterViewInit() {
    this.paymentModal.onCancel = () => {
      this.refresh(false);
    }
    this.paymentModal.onSuccess = data => {
      this.paymentTable.refresh();
    }
    this.setPaymentModalApiUrl();
  }

  refresh(loading = true) {
    this.get(this.objectId, loading);
  }

  get(id, loading: boolean = true) {
    if (loading) {
      this.loading = true;
    }
    const fetchApi = `${this.apiUrl}/${id}`;
    if (fetchApi) {
      this.subscribe(this._httpService.get(fetchApi),
        (res: any) => {
          if (loading) {
            this.loading = false;
          }
          if (res) {
            this.model = res.data;
            this.contact = res.data?.customer;

            if (this.model?.items) {
              this.subtotal = this.model.items.reduce((a, c) => a + c.subtotal, 0);
              this.total = this.model.items.reduce((a, c) => a + c.total, 0);
              this.paymentModalData.invoiceTotal = this.total;
            }

            const smallerObjectName = this._translate.instant(this.objectName).toLowerCase();
            this.paymentModalData = {
              title: this._translate.instant('add.payment.for.x0.x1', {
                x0: smallerObjectName,
                x1: this.model.number
              }),
              mode: 'add',
              amount: this.model.amountDue,
              currency: this.currency
            }

            if (this.model.adjustmentAmount) {
              const isPositive = this.model.adjustmentAmount > 0
              this.model.adjustmentPrefix = isPositive ? '' : '(-)';
              this.model.adjustmentColor = isPositive ? 'black' : 'red';
              this.model.adjustmentAmount = Math.abs(this.model.adjustmentAmount);
            }

            this.setPaymentModalApiUrl();
            this.invoke(this.onGetData, res.data);
          }
        },
        err => {
          if (loading) {
            this.loading = false;
          }
        }
      );
    }
  }

  setPaymentModalApiUrl() {
    if (this.paymentModal) {
      this.paymentModal.buildApiUrl = data => {
        return `${this.apiUrl}/${this.objectId}/payments`;
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
    this._router.navigateByUrl(`${this.apiUrl}/${this.objectId}/edit`);
  }

  add() {
    this._router.navigateByUrl(`${this.apiUrl}/create`);
  }

  cancel() {
    this.location.back();
  }

  print() {
    this.subscribe(this._httpService.get(`${this.apiUrl}/${this.objectId}/print`),
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
