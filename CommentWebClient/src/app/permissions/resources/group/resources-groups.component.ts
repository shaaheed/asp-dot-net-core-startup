import { Component } from '@angular/core';
import { NzModalService, NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { ResourcesGroupsAddComponent } from './add/resources-groups-add.component';
import { PermissionsHttpService as PermissionsHttpService } from 'src/services/http/permissions-http.service';

@Component({
  selector: 'app-resources-groups',
  templateUrl: './resources-groups.component.html',
  styleUrls: ['./resources-groups.component.scss']
})
export class ResourcesGroupsComponent {

  loading: boolean = false;
  total: number = 100;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfData = [];
  tableHeader: any = {};

  constructor(
    private modalService: NzModalService,
    private permissionHttpService: PermissionsHttpService,
    private messageService: NzMessageService
  ) {

    this.tableHeader = {
      title: 'Resource Groups',
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
    this.loading = true;
    console.log('resource group');
    this.gets();
  }

  add(model = null) {

    const $this = this;

    const modal: NzModalRef = this.modalService.create({
      nzTitle: `${model ? 'Edit' : 'Add'} Resource Group`,
      nzContent: ResourcesGroupsAddComponent,
      nzComponentParams: {
        selectedResources: model ? model.resources.map(x => {
          return {
            code: x.code,
            name: x.name,
            id: x.id,
            selectedOperations: x.operations.map(y => y.id)
          }
        }) : [],
        name: model ? model.name : ""
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
            const instance: ResourcesGroupsAddComponent = (<any>modal).contentComponentRef.instance
            this.loading = true;
            const resources = instance.selectedResources.map(x => {
              return {
                resourceId: x.id,
                operationIds: x.selectedOperations
              }
            })
            const body = {
              name: instance.name,
              resources: resources
            }
            
            const request = model ? $this.permissionHttpService.editResourceGroups(model.id, body) : $this.permissionHttpService.addResourceGroups(body);
            request.subscribe(
              res => {
                this.loading = false;
                modal.destroy();
                $this.messageService.create('success', `${instance.name} created.`);
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

  delete(e) {
    const deleteModal = this.modalService.confirm({
      nzTitle: 'Confirm',
      nzContent: `Do you want to delete ${e.code}?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        deleteModal.getInstance().nzOkLoading = true;
        this.permissionHttpService.deleteResourceGroup(e.id).subscribe(
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.create('success', `${e.code} deleted.`);
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

  edit() {

  }

  gets() {
    this.permissionHttpService.getResourceGroups().subscribe(
      (res: any[]) => {
        this.loading = false;
        console.log(res);
        res.forEach(item => {
          item.resources.forEach(r => {
            r.operationString = r.operations.map(x => x.code).join(', ')
          });
        }); 
        this.listOfData = res;
      },
      err => {
        this.loading = false;
        console.log('err', err)
      }
    );
  }

}
