import { Component } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
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
  id: any = null;
  subtotal: any = "-";
  total: any = "-";
  visible: boolean = true;
  showCustomer: boolean = false;
  showPaymentModal: boolean = false;
  paymentModalData: any = {}

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
    this.id = snapshot.params.id
    this.paymentModalData.invoiceId = this.id;
    this.get(this.id);

    this.paymentModalData = {
      title: `Add payment for invoice #` + this.id,
      mode: 'add',
      invoiceId: this.id
    }
  }

  refresh() {
    // this.get();
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.invoiceService.get(id),
      (res: any) => {
        this.model = res;
        this.loading = false;
        if (res.items) {
          this.subtotal = res.items.reduce((a, c) => a + c.subtotal, 0);
          this.total = res.items.reduce((a, c) => a + c.total, 0);
          this.paymentModalData.invoiceTotal = this.total;
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
        deleteModal.getInstance().nzOkLoading = true;
        this.subscribe(this.invoiceService.delete(e.id),
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.success('Successfully deleted');
            // this.get();
          },
          err => {
            deleteModal.getInstance().nzOkLoading = false;
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
