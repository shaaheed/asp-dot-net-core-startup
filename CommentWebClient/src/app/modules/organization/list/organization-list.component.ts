import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OrganizationService } from 'src/services/organization.service';
import { TableComponent } from 'src/app/shared/table.component';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html'
})
export class OrganizationListComponent extends TableComponent {

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      // permissions: ['course.manage', 'course.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      // permissions: ['course.manage', 'course.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private organizationService: OrganizationService,
    private router: Router
  ) {
    super(organizationService);
  }

  ngOnInit() {
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.router.navigateByUrl(`/organizations/${model.id}/edit`);
    }
    else {
      this.router.navigateByUrl('/organizations/create');
    }
  }

  gets() {
    this.load();
  }

  refresh() {
    this.gets();
  }

}
