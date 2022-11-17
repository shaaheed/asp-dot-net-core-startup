import { Component, HostListener } from '@angular/core';
import { UntypedFormGroup, UntypedFormArray, AbstractControl } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { forEachObj } from 'src/services/utilities.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ValidatorService } from 'src/services/validator.service';

@Component({
  selector: 'app-units-add',
  templateUrl: './units-add.component.html',
  styleUrls: ['./units-add.component.scss']
})
export class UnitsAddComponent extends FormComponent {

  apiUrl = 'units/types';
  objectName = 'unit';

  units: any[] = [];
  formItemStyle = { padding: 0 };

  onSetFormValues = data => {
    this.prepareForm(data);
  };

  constructor(
    private route: ActivatedRoute,
    private validator: ValidatorService
  ) {
    super();
  }

  ngOnInit(): void {
    const data = this.route.snapshot.data;
    if (data?.componentAccessor) {
      data.componentAccessor(this);
    }
    super.ngOnInit(this.route.snapshot);
    this.createForm({
      name: [null, [], this.validator.required()],
      units: this.fb.array([])
    });

    if (this.isEditMode()) {
      this.loading = true;
      this.subscribe(
        this._httpService.get(`units?Filter=TypeId eq ${this.id}`),
        (res: any) => {
          this.loading = false;
          if (res?.data?.items) {
            this.units = res.data.items;
            if (!this.units?.length) {
              setTimeout(() => this.addLineItem(), 0);
            }
            else {
              this.prepareForm({ units: this.units });
            }
          }
        },
        err => this.loading = false
      );
    }

    if (this.isAddMode()) {
      setTimeout(() => this.addLineItem(), 0);
    }
  }

  @HostListener('window:keyup', ['$event'])
  onKeyup(event: any) {
    console.log('keyup..', event);
  }

  addLineItem(item = {}) {
    this.createLineItemFormGroup(item);
  }

  deleteLineItem(index) {
    const lineItems = this.getLineItemsFormArray();
    if (lineItems.length) {
      lineItems.removeAt(index);
      if (!lineItems.length) {
        this.addLineItem();
      }
    }
  }

  onFormKeyup(event: KeyboardEvent) {
    this.log('onFormKeyup', event);
  }

  private prepareForm(data) {
    this.form.controls.units = this.fb.array([]);
    if (data?.units?.length) {
      data.units.forEach(x => {
        const o = {
          id: x.id,
          typeId: x.typeId,
          name: x.name,
          conversionRate: x.conversionRate,
          isBaseUnit: x.isBaseUnit,
        }
        this.createLineItemFormGroup(o);
      });
    }
  }

  private createLineItemFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      name: [null, [], this.validator.required()],
      conversionRate: [null, [], this.validator.required()],
      isBaseUnit: [],
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const lineItems = this.getLineItemsFormArray();
    lineItems.push(formGroup);
  }

  private getLineItemsFormArray(): UntypedFormArray {
    return this.form.get("units") as UntypedFormArray;
  }

  private isEmptyLineItem(lineItem: UntypedFormGroup): boolean {
    let isEmpty = true;
    ['name', 'quantity', 'unitPrice'].forEach(key => {
      isEmpty &&= !lineItem.controls[key].value;
    });
    return isEmpty;
  }

}
