import { Component } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Router, ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../services/invoice.service';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-invoice-payments-list',
  templateUrl: './payments-list.component.html',
  styleUrls: ['./payments-list.component.scss']
})
export class InvoicePaymentListComponent extends BaseComponent {

  loading: boolean = false;
  noData: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];
  
  private invoiceId: number

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
    this.invoiceId = snapshot.data.invoiceId;
    this.gets(this.invoiceId);
  }

  refresh() {
    this.gets(this.invoiceId);
  }

  add(model = null) {
    if (model) {
      this.router.navigateByUrl(`/invoices/${model.id}/edit`);
    }
    else {
      this.router.navigateByUrl('/invoices/create');
    }
  }

  view(model) {
    this.router.navigateByUrl(`/invoices/${model.id}/view`);
  }

  gets(invoiceId: number) {
    this.loading = true;
    this.subscribe(this.invoiceService.getPayments(invoiceId),
      (res: any[]) => {
        this.listOfData = res;
        this.loading = false;
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
        // deleteModal.nzOkLoading = true;
        this.subscribe(this.invoiceService.delete(e.id),
          res => {
            // deleteModal.getInstance().nzOkLoading = false;
            this.messageService.success('Successfully deleted');
            this.gets(this.invoiceId);
          },
          err => {
            // deleteModal.getInstance().nzOkLoading = false;
            console.log('err', err)
          }
        );
      }
    });
  }

}
