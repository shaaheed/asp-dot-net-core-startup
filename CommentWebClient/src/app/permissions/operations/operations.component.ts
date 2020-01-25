import { Component } from '@angular/core';
import { NzModalService, NzModalRef } from 'ng-zorro-antd';
import { OperationsAddComponent } from './add/operations-add.component';
import { PermissionsHttpService } from 'src/services/http/permissions-http.service';

@Component({
  selector: 'app-operations',
  templateUrl: './operations.component.html',
  styleUrls: ['./operations.component.scss']
})
export class OperationsComponent {

  loading: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];

  constructor(
    private modalService: NzModalService,
    private permissionService: PermissionsHttpService
  ) {

  }

  ngOnInit() {
    this.loading = true;
    this.permissionService.getResources().subscribe(
      (res: any[]) => {
        this.loading = false;
        console.log(res);
        const r = res.map(x => {
          return {
            name: x.name,
            code: x.code
          }
        });
        this.listOfData = r;
      },
      err => {
        this.loading = false;
        console.log('err', err)
      }
    );
  }

  add() {

    const modal: NzModalRef = this.modalService.create({
      nzTitle: 'Add Resource',
      nzContent: OperationsAddComponent,
      nzFooter: [
        {
          label: 'Cancel',
          shape: 'default',
          onClick: () => modal.destroy()
        },
        {
          label: 'Add',
          type: 'primary',
          loading: false,
          onClick(): void {
            this.loading = true;
            setTimeout(() => (this.loading = false), 1000);
            setTimeout(() => {
              this.loading = false;
              this.disabled = true;
            }, 2000);
          }
        }
      ]
    });
  }



}
