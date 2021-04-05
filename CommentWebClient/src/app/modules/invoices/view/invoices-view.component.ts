import { Component } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Router, ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../services/invoice.service';
import { BaseComponent } from 'src/app/shared/base.component';

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
  invoiceId

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private invoiceService: InvoiceService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {

    const snapshot = this.activatedRoute.snapshot;
    this.invoiceId = snapshot.params.id;
    this.paymentModalData.invoiceId = this.invoiceId;
    this.get(this.invoiceId);
  }

  refresh() {
    // this.get();
  }

  get(id) {
    this.loading = true;
    this.subscribe(this._httpService.get(`invoices/${id}`),
      (res: any) => {
        this.model = res.data;
        this.loading = false;
        if (this.model?.items) {
          this.subtotal = this.model.items.reduce((a, c) => a + c.subtotal, 0);
          this.total = this.model.items.reduce((a, c) => a + c.total, 0);
          this.paymentModalData.invoiceTotal = this.total;
        }
        this.paymentModalData = {
          title: this._translate.instant('add.payment.for.invoice.x0', {x0: this.model.code}),
          mode: 'add',
          amount: this.model.amountDue
        }
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  delete(e) {
    const deleteModal = this.modalService.confirm({
      nzTitle: 'Confirm',
      nzContent: `Do you want to delete?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        // deleteModal.getInstance().nzOkLoading = true;
        this.subscribe(this.invoiceService.delete(e.id),
          res => {
            // deleteModal.getInstance().nzOkLoading = false;
            this.messageService.success('Successfully deleted');
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

  showCustomerDrawer() {
    this.showCustomer = !this.showCustomer
  }

  closeCustomerDrawer() {
    this.showCustomer = false;
  }

  payment() {
    this.showPaymentModal = true;
  }

  add() {
    
  }

}
