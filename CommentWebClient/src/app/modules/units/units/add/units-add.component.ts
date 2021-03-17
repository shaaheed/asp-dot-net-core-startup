import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-units-add',
  templateUrl: './units-add.component.html'
})
export class UnitsAddComponent extends FormComponent {

  loading: boolean = false;
  noData: boolean = false;
  apiUrl = 'units';
  cancelRoute = 'units';
  objectName = "unit";

  @ViewChild('typeSelect') typeSelect: SelectControlComponent;

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
      typeId: [null, [], [
        this.validator.required().bind(this)
      ]],
      symbol: [null, [], [
        this.validator.required().bind(this)
      ]],
      description: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.typeSelect.register((pagination, search) => {
      return this._httpService.get('units/types');
    });
  }
}
