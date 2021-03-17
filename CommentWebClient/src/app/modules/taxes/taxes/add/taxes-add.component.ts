import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-taxes-add',
  templateUrl: './taxes-add.component.html'
})
export class TaxesAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'taxes';
  cancelRoute = 'taxes';
  objectName = "tax";

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
      taxNumber: [],
      rate: [null, [], [
        this.validator.required().bind(this)
      ]],
      isCompound: [],
      description: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }
}
