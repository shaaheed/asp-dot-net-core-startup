import { Component, HostListener } from '@angular/core';
import { UntypedFormGroup, UntypedFormArray, AbstractControl } from '@angular/forms';
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

  apiUrl = 'systems/units/types';
  objectName = 'unit';

  units: any[] = [];
  formItemStyle = { padding: 0 };

  baseUnitName: string = "";

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

    if (this.isAddMode()) {
      setTimeout(() => this.addUnit(), 0);
    }
  }

  @HostListener('window:keyup', ['$event'])
  onKeyup(event: any) {
    console.log('keyup..', event);
  }

  addUnit(item = {}) {
    this.createUnitFormGroup(item);
  }

  deleteUnit(index) {
    const units = this.getUnitsFormArray();
    if (units.length) {
      units.removeAt(index);
      if (!units.length) {
        this.addUnit();
      }
    }
  }

  onUnitBaseChanged(i, e) {
    if (e) {
      const units = this.getUnitsFormArray();
      if (units.length) {
        this.baseUnitName = (units?.controls[i] as any)?.controls?.name?.value || "";
      }
    }
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
        if (x.isBaseUnit) {
          this.baseUnitName = x.name;
        }
        this.createUnitFormGroup(o);
      });
    }
  }

  private createUnitFormGroup(data: any) {
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
    const units = this.getUnitsFormArray();
    units.push(formGroup);
  }

  private getUnitsFormArray(): UntypedFormArray {
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
