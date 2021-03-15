import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-unit-types-add',
  templateUrl: './types-add.component.html'
})
export class UnitTypesAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  url = 'units/types';
  cancelRoute = 'units/types';
  addTitle = 'create.a.x0|{"x0":"unit.type"}';
  editTitle = 'update.a.x0|{"x0":"unit.type"}';

  constructor(
    private activatedRoute: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], [
        this.validator.required().bind(this),
        this.validator.min(2).bind(this)
      ]],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }
}
