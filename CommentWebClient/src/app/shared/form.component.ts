import { ActivatedRouteSnapshot } from '@angular/router';
import { FormBaseComponent } from './form-base.component';
import { Directive } from "@angular/core";

@Directive()
export class FormComponent extends FormBaseComponent {

    constructor() {
        super();
    }

    ngOnInit(snapshot: ActivatedRouteSnapshot) {
        this.snapshot(snapshot);
        this.init();
    }

}
