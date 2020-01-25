import { FormGroup, FormBuilder } from '@angular/forms';
import { AppInjector } from 'src/app/app.component';
import { Observable } from 'rxjs';
import { BaseComponent } from './base.component';
import { ActivatedRouteSnapshot } from '@angular/router';

export class FormComponent extends BaseComponent {

    mode: string = "none";
    submitButtonText: string = "";
    form: FormGroup;
    id: number;
    submitting: boolean = false;

    onCheckMode: (id: number) => void;
    onUpdate: (id: number) => Observable<Object>;
    onCreate: () => Observable<Object>;
    onFail: (err: any) => void;
    onSuccess: (data: any) => void;

    private static ADD = "add";
    private static EDIT = "edit";

    constructor() {
        super();
    }

    ngOnInit(snapshot: ActivatedRouteSnapshot) {
        this._activatedRouteSnapshot = snapshot;
        this.checkMode(this.onCheckMode);
    }

    update(options: IRequestOptions): void {
        if (this.isEditMode()) {
            this.validateForm(() => {
                if (options && options.request) {
                    this.submitting = true;
                    this.subscribe(options.request,
                        (s: any) => {
                            this.submitting = false;
                            this.invoke(this.onSuccess, s);
                            this.invoke(options.succeed, s);
                        },
                        e => {
                            this.submitting = false;
                            this.invoke(this.onFail, e);
                            this.invoke(options.failed, e);
                        }
                    );
                }
            });
        }
    }

    create(options: IRequestOptions): void {
        if (this.isAddMode()) {
            this.validateForm(() => {
                if (options && options.request) {
                    this.submitting = true;
                    this.subscribe(options.request,
                        s => {
                            this.submitting = false;
                            this.invoke(this.onSuccess, s);
                            this.invoke(options.succeed, s);
                        },
                        e => {
                            this.submitting = false;
                            this.invoke(this.onFail, e);
                            this.invoke(options.failed, e);
                        }
                    );
                }
            });
        }
    }

    markModeAsAdd(): void {
        this.mode = FormComponent.ADD;
        this.submitButtonText = "Create";
    }

    isAddMode(): boolean {
        return this.mode == FormComponent.ADD;
    }

    isEditMode(): boolean {
        return this.mode == FormComponent.EDIT
    }

    markModeAsEdit(): void {
        this.mode = FormComponent.EDIT;
        this.submitButtonText = "Update";
    }

    checkMode(fn: (id: number) => void, paramKey: string = 'id'): void {
        this.id = this.getQueryParams(paramKey);
        if (this.id) {
            this.markModeAsEdit();
            this.invoke(fn, this.id);
        } else {
            this.markModeAsAdd();
        }
    }

    createForm(controlsConfig: { [key: string]: any; }): void {
        this.form = AppInjector.get(FormBuilder).group(controlsConfig);
    }

    validateForm(fn: () => void) {
        this.busy();
        for (const i in this.form.controls) {
            this.form.controls[i].markAsDirty();
            this.form.controls[i].updateValueAndValidity();
        }
        if (this.form.valid) {

            this.invoke(fn);
        }
        else {
            this.busy(false);
        }
    }

    submitForm(createOptions: IRequestOptions, updateOptions: IRequestOptions) {
        if (this.isAddMode()) {
            this.create(createOptions);
        }
        else if (this.isEditMode()) {
            this.update(updateOptions);
        }
    }

}

export interface IRequestOptions {
    request: Observable<Object>;
    succeed?: (data: any) => void;
    failed?: (err: any) => void;
}
