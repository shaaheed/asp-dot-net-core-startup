import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from 'src/app/shared/form.component';

@Component({
  selector: 'app-users-add',
  templateUrl: './users-add.component.html'
})
export class UsersAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  url = 'users';
  cancelRoute = 'users';
  addTitle = 'create.a.x0|{"x0":"user"}';
  editTitle = 'update.a.x0|{"x0":"user"}';

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      firstName: [],
      email: [],
      mobile: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

}
