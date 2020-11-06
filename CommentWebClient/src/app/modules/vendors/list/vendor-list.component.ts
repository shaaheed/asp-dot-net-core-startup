import { Component } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Router } from '@angular/router';
import { VendorService } from '../vendor.service';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.scss']
})
export class VendorListComponent {

  loading: boolean = false;
  noData: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private vendorService: VendorService,
    private router: Router
  ) {

  }

  ngOnInit() {
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.router.navigateByUrl(`/vendors/${model.id}/edit`);
    }
    else {
      this.router.navigateByUrl('/vendors/create');
    }
  }

  gets() {
    this.loading = true;
    this.vendorService.gets().subscribe(
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

  refresh() {
    this.gets();
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
        this.vendorService.delete(e.id).subscribe(
          res => {
            // deleteModal.getInstance().nzOkLoading = false;
            this.messageService.success(`Successfully deleted.`);
            this.gets();
          },
          err => {
            // deleteModal.getInstance().nzOkLoading = false;
            if(err.error && err.error.message) {
              this.messageService.error(err.error.message);
            }
          }
        );
      }
    });
  }

}
