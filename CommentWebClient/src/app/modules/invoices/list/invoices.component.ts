import { Component } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { Router } from '@angular/router';
import { InvoiceService } from '../services/invoice.service';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.scss']
})
export class InvoicesComponent extends BaseComponent {

  loading: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private invoiceService: InvoiceService,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    this.gets();
  }

  refresh() {
    this.gets();
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

  gets() {
    this.loading = true;
    this.invoiceService.gets().subscribe(
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
        deleteModal.getInstance().nzOkLoading = true;
        this.subscribe(this.invoiceService.delete(e.id),
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.success('Successfully deleted');
            this.gets();
          },
          err => {
            deleteModal.getInstance().nzOkLoading = false;
            console.log('err', err)
          }
        );
      }
    });
  }

}
