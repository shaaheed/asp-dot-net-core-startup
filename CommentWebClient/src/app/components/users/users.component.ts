import { Component } from '@angular/core';
import { NzModalService, NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { UsersHttpService } from 'src/services/http/users-http.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {

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
      title: 'Users',
      buttons: [
        {
          label: 'Add',
          type: 'custom',
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
      nzTitle: `${model ? 'Edit' : 'Add'} User`,
      nzContent: 'UsersAddComponent',
      nzComponentParams: {
        email: model ? model.email : '',
        firstname: model ? model.firstName : '',
        lastname: model ? model.lastName : '',
        selectedGroups: model && model.groups ? model.groups.map(x => x.id) : [],
        mode: model ? 'edit' : 'add'
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
            const instance = (<any>modal).contentComponentRef.instance
            this.loading = true;
            const body = {
              firstName: instance.firstname,
              lastName: instance.lastname,
              email: instance.email,
              userGroupIds: instance.selectedGroups
            };

            const request = model ? $this.userHttpService.editUser(model.id, body) : $this.userHttpService.addUser(body);
            request.subscribe(
              res => {
                $this.gets();
                modal.destroy();
                this.loading = false;
                const fullName = `${instance.firstname} ${instance.lastname}`.trim()
                const msg = `${fullName} ${model ? 'updated' : 'created'}.`
                $this.messageService.create('success', msg);
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
    this.userHttpService.getUsers().subscribe(
      (res: any[]) => {
        this.listOfData = res.map(x => {
          return {
            name: this.formatUsername(x),
            email: x.email,
            groups: x.groups,
            id: x.id,
            firstName: x.firstName,
            lastName: x.lastName
          }
        });
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
      nzContent: `Do you want to delete ${this.formatUsername(e)}?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        deleteModal.getInstance().nzOkLoading = true;
        this.userHttpService.deleteUser(e.id).subscribe(
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
