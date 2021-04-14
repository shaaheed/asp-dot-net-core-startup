import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { message } from 'src/constants/message';
import { TranslateService } from '@ngx-translate/core';
import { map } from 'rxjs/operators';
import { AppInjector } from 'src/app/app/app.component';

@Injectable()
export class ValidatorService {

  _translate: TranslateService;

  constructor() {
    this._translate = AppInjector.get(TranslateService);
  }

  required(error?: string) {
    return (control: FormControl) => {
      if (!control.value) {
        return this.error(error || message.this_field_is_required);
      }
      return of(true);
    }
  }

  requiredDate(error?: string) {
    return this.required(error || message.select_date);
  }

  amount(max?: number, mustBePositive: boolean = true) {
    return (control: FormControl) => {
      if (!control.value) {
        return this.error(message.amount_is_required);
      }
      else if (isNaN(Number(control.value))) {
        return this.error(message.amount_must_be_numeric);
      }
      else if (mustBePositive && Number(control.value) <= 0) {
        return this.error(message.amount_must_be_positive);
      }
      else if (max && Number(control.value) > max) {
        return this.error(message.amount_exceeds);
      }
      return of(true);
    }
  }

  max(max: number) {
    return (control: FormControl) => {
      if (control.value && control.value.length > max) {
        return this.error(message.equal_or_less_x0_letters, { x0: max });
      }
      return of(true);
    }
  }

  min(min: number) {
    return (control: FormControl) => {
      if (control.value && control.value.length < min) {
        return this.error(message.equal_or_greater_x0_letters, { x0: min });
      }
      return of(true);
    }
  }

  mobile(error?: string) {
    return (control: FormControl) => {
      if (!control.value) {
        return this.error(error || message.this_field_is_required);
      }
      else if (isNaN(control.value)) {
        return this.error(message.must_be_numeric);
      }
      else if (control.value.length != 11) {
        return this.error(message.equal_or_greater_x0_letters, { x0: 11 });
      }
      return of(true);
    }
  }

  combine(...validators: []) {
    
  }

  protected error(key: string, interpolateParams?: Object) {
    return this._translate.get(key, interpolateParams).pipe(
      map(res => {
        return {
          error: true,
          message: res
        }
      })
    )
  }

}