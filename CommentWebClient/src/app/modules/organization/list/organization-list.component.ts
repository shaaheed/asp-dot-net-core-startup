import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { OrganizationHttpService } from 'src/app/modules/organization/organization-http.service';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html'
})
export class OrganizationListComponent {

  fetch = (pagination, search) => {
    return this.organizationHttpService.list(pagination, search);
  };

  constructor(
    private organizationHttpService: OrganizationHttpService,
    private router: Router
  ) {
  }

  ngOnInit() {
    //
  }

  add(model = null) {
    if (model) {
      this.router.navigateByUrl(`/organizations/${model.id}/edit`);
    }
    else {
      this.router.navigateByUrl('/organizations/create');
    }
  }

}
