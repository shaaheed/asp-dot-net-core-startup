import { Component } from '@angular/core';
import { NzModalService, NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { UsersGroupsAddComponent } from './add/users-groups-add.component';
import { UsersHttpService } from 'src/services/http/users-http.service';

@Component({
  selector: 'app-users-groups',
  templateUrl: './users-groups.component.html',
  styleUrls: ['./users-groups.component.scss']
})
export class UsersGroupsComponent {

  loading: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];
  tableHeader: any = {};

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private userHttpService: UsersHttpService
  ) {

    this.tableHeader = {
      title: 'User Groups',
      buttons: [
        {
          label: 'Add',
          type: 'primary',
          action: () => {
            this.add();
          }
        }
      ]
    }

  }

  ngOnInit() {
    this.gets();
  }

  add(model = null) {

    const $this = this;

    const modal: NzModalRef = this.modalService.create({
      nzTitle: `${model ? 'Edit' : 'Add'} Group`,
      nzContent: UsersGroupsAddComponent,
      nzComponentParams: {
        name: model ? model.name : ''
      },
      nzFooter: [
        {
          label: 'Cancel',
          shape: 'default',
          onClick: () => modal.destroy()
        },
        {
          label: model ? 'Edit' : 'Add',
          type: 'primary',
          loading: false,
          onClick(): void {
            const instance: UsersGroupsAddComponent = (<any>modal).contentComponentRef.instance
            this.loading = true;
            const body = {
              name: instance.name
            };
            const request = model ? $this.userHttpService.editUserGroup(model.id, body) : $this.userHttpService.addUserGroup(body)
            request.subscribe(
              res => {
                this.loading = false;
                modal.destroy();
                const msg = `${instance.name} ${model ? 'updated' : 'created'}.`
                $this.messageService.create('success', msg);
                $this.gets();
              },
              err => {
                this.loading = false;
                console.log('err', err);
              }
            );
          }
        }
      ]
    });
  }

  gets() {
    this.loading = true;
    this.userHttpService.getUserGroups().subscribe(
      (res: any[]) => {
        this.listOfData = res.map(x => {
          return {
            name: x.name,
            id: x.id
          }
        })
      },
      err => {
        console.log(err)
      },
      () => {
        this.loading = false;
      }
    );
  }

  delete(e) {
    const deleteModal = this.modalService.confirm({
      nzTitle: 'Confirm',
      nzContent: `Do you want to delete ${this.formatUsername(e)}?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        deleteModal.getInstance().nzOkLoading = true;
        this.userHttpService.deleteUserGroup(e.id).subscribe(
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.create('success', `${this.formatUsername(e)} deleted.`);
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

  private formatUsername(user) {
    let name = ""
    if (user.firstName) {
      name += user.firstName
    }
    if (user.lastName) {
      name += ` ${user.lastName}`
    }
    return name;
  }

}
