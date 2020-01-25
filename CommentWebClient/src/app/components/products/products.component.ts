import { Component } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ProductsHttpService as ProductService } from 'src/services/http/products-http.service';
import { Router } from '@angular/router';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends BaseComponent {

  loading: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private productService: ProductService,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.router.navigateByUrl(`/products/${model.id}/edit`);
    }
    else {
      this.router.navigateByUrl('/products/create');
    }
  }

  gets() {
    this.loading = true;
    this.subscribe(this.productService.gets(),
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
        deleteModal.getInstance().nzOkLoading = true;
        this.subscribe(this.productService.delete(e.id),
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.success(`Successfully deleted`);
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
