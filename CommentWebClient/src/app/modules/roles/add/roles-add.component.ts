import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from 'src/app/shared/form.component';

@Component({
  selector: 'app-roles-add',
  templateUrl: './roles-add.component.html'
})
export class RolesAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'roles';
  cancelRoute = 'roles';

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [],
      description: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

}
