import { FormGroup, FormBuilder } from '@angular/forms';
import { AppInjector } from 'src/app/app.component';
import { Observable } from 'rxjs';
import { BaseComponent } from './base.component';
import { forEachObj } from 'src/services/utilities.service';
import { NzModalComponent } from 'ng-zorro-antd/modal';
import { m } from 'src/constants/message';

export class FormBaseComponent extends BaseComponent {

    mode: string = "none";
    submitButtonText: string = "";
    form: FormGroup;
    id: number;
    submitting: boolean = false;
    loading: boolean = false;

    url: string;
    cancelRoute: string;

    onCheckMode: (id: number) => void;
    onUpdate: (id: number) => Observable<Object>;
    onCreate: () => Observable<Object>;
    onFail: (err: any) => void;
    onSuccess: (data: any) => void;
    onSetFormValues: (data?: any) => void;

    fb: FormBuilder;
    modalInstance: NzModalComponent;
    private static ADD = "add";
    private static EDIT = "edit";

    constructor() {
        super();
        this.fb = AppInjector.get(FormBuilder);
    }

    init() {
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
                            this.bindServerValidationErrorsWithFormControls(e);
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
                            this.bindServerValidationErrorsWithFormControls(e);
                        }
                    );
                }
            });
        }
    }

    markModeAsAdd(): void {
        this.mode = FormBaseComponent.ADD;
        this.submitButtonText = 'create';
    }

    isAddMode(): boolean {
        return this.mode == FormBaseComponent.ADD;
    }

    isEditMode(): boolean {
        return this.mode == FormBaseComponent.EDIT
    }

    markModeAsEdit(): void {
        this.mode = FormBaseComponent.EDIT;
        this.submitButtonText = "update";
    }

    checkMode(fn: (id: number) => void, paramKey: string = 'id'): void {
        const id = this.getQueryParams(paramKey);
        if (id) {
            this.id = id;
        }
        if (this.id) {
            this.markModeAsEdit();
            this.invoke(fn, this.id);
            this.get();
        } else {
            this.invoke(fn, null);
            this.markModeAsAdd();
        }
    }

    createForm(controlsConfig: { [key: string]: any; }): void {
        this.form = this.fb.group(controlsConfig);
    }

    submitForm(createOptions: IRequestOptions, updateOptions: IRequestOptions) {
        if (this.isAddMode()) {
            this.create(createOptions);
        }
        else if (this.isEditMode()) {
            this.update(updateOptions);
        }
    }

    submit() {
        const body = this.constructObject(this.form.controls);
        if (this.isAddMode() && this.url && body) {
            this.create({
                request: this._httpService.post(this.url, body),
                succeed: res => {
                    this.cancel();
                    this.success(m.successfully_created);
                }
            });
        }
        else if (this.isEditMode() && this.id && this.url && body) {
            const _url = `${this.url}/${this.id}`;
            this.update({
                request: this._httpService.put(_url, body),
                succeed: res => {
                    this.cancel();
                    this.success(m.successfully_updated);
                }
            });
        }
    }

    setValue(controlName: string, value: any): void {
        if (this.form.controls[controlName]) {
            this.form.controls[controlName].setValue(value);
        }
    }

    cancel() {
        if (this.cancelRoute) {
            this._router.navigateByUrl(this.cancelRoute);
        }
    }

    get() {
        if (this.id && this.url) {
            this.loading = true;
            const _url = `${this.url}/${this.id}`;
            this.subscribe(this._httpService.get(_url),
                (res: any) => {
                    this.setValues(this.form.controls, res.data);
                    this.invoke(this.onSetFormValues, res.data);
                    this.loading = false;
                }
            )
        }
        else {
            this.loading = false;
        }
    }

    validateForm(fn?: () => void) {
        this.busy();
        this.markDirtyAndCheckValidity(this.form.controls);
        if (this.form.valid) {
            this.invoke(fn);
        }
        else {
            this.log('INVALID FORM', this.form);
            this.busy(false);
        }
        return this.form.valid;
    }

    bindServerValidationErrorsWithFormControls(e) {
        if (e.error && e.error.message == "form_error") {
            forEachObj(this.form.controls, (k, v) => {
                const data = e.error.data.filter(x => x.field.toLowerCase() == k.toLowerCase());
                if (data && data.length > 0) {
                    const err = { message: data[data.length - 1].message }
                    v.setErrors(err);
                }
            });
        }
    }

    markDirtyAndCheckValidity(controls) {
        for (const i in controls) {
            controls[i].markAsDirty();
            controls[i].updateValueAndValidity();
            const ctr = controls[i].constructor.name;
            if (ctr == "FormArray") {
                for (let a = 0; a < controls[i].length; a++) {
                    const _controls = controls[i].controls[a].controls;
                    this.markDirtyAndCheckValidity(_controls);
                }
            }
        }
    }

    closeModal(result = {}) {
        if (this.modalInstance) {
            this.modalInstance.close(result);
        }
    }

}

export interface IRequestOptions {
    request: Observable<Object>;
    succeed?: (data: any) => void;
    failed?: (err: any) => void;
}
