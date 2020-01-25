import { Component } from '@angular/core';
import { NzModalService, NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { PermissionsHttpService } from 'src/services/http/permissions-http.service';

@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.scss']
})
export class ResourcesComponent {

  loading: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];

  constructor(
    private modalService: NzModalService,
    private permissionService: PermissionsHttpService,
    private message: NzMessageService
  ) {

  }

  ngOnInit() {
    this.gets();
  }

  gets() {
    this.loading = true;
    this.permissionService.getResources().subscribe(
      (res: any[]) => {
        this.listOfData = res;
      },
      err => {
        console.log('err', err)
      },
      () => {
        this.loading = false;
      }
    );
  }

  add() {

    const modal: NzModalRef = this.modalService.create({
      nzTitle: 'Add Resource',
      nzContent: 'ResourcesAddComponent',
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

  sync() {
    this.loading = true;
    this.permissionService.seeds().subscribe(
      res => {
        this.message.create('success', 'Seeding success.');
        this.gets();
      },
      err => {
        console.log('err', err)
        this.message.create('success', 'Seeding failed.');
      },
      () => {
        this.loading = true;
      }
    );
  }



}
