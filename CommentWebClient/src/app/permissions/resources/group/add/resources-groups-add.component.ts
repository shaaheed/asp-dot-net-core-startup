import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { PermissionsHttpService } from 'src/services/http/permissions-http.service';

@Component({
  selector: 'app-resources-groups-add',
  templateUrl: './resources-groups-add.component.html',
  styleUrls: ['./resources-groups-add.component.scss']
})
export class ResourcesGroupsAddComponent {

  validateForm: FormGroup;
  name: string = "";
  resources: any[] = [];
  selectedResources: any[];
  loading = true;

  constructor(
    private fb: FormBuilder,
    private permissionService: PermissionsHttpService
  ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      name: [null, [Validators.required]]
    });
    this.addControls(this.selectedResources);
    this.getResources();
  }

  getResources() {
    this.loading = true;
    this.permissionService.getResources().subscribe(
      (res: any[]) => {
        this.loading = false;
        this.resources = res;
        this.resources.forEach(r => {
          this.selectedResources.forEach(x => {
            if (x.id === r.id) {
              x.operations = r.operations;
            }
          });
        });
      },
      err => {
        this.loading = false;
        console.log('err', err);
      }
    );
  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
  }

  addResource(resource) {
    const name = this.getResourceControlName(resource);
    const control = this.validateForm.controls[name];
    if (!control) {
      this.addControl(name);
    }
    const resourceToBeAdd = {
      id: resource.id,
      code: resource.code,
      selectedOperations: [],
      operations: resource.operations
    }
    this.selectedResources.push(resourceToBeAdd)
  }

  removeResource(resource) {
    const indexOf = this.selectedResources.indexOf(resource);
    if(indexOf > -1) {
      this.selectedResources.splice(indexOf, 1);
    }
  }

  private addControls(resources) {
    resources.forEach(r => {
      const name = this.getResourceControlName(r);
      this.addControl(name);
    });
  }

  private addControl(name) {
    this.validateForm.addControl(name, new FormControl())
  }

  private getResourceControlName(resource) {
    return `resource_${resource.code}`;
  }


}
