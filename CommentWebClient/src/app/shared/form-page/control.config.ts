import { FormGroup } from "@angular/forms";
import { ValidatorService } from "src/services/validator.service";
import { ControlComponent } from "../control.component";

export interface InputConfig extends ControlConfig {
    type?: string;
    suffix?: string;
    prefix?: string;
}

export interface CheckboxConfig extends ControlConfig {
    info?: string;
}

export interface ControlConfig {
    name: string;
    controlType: ControlType;
    label: string;
    placeholder?: string;
    onChange?: (value: any) => void;
    mandatory?: boolean;
    tooltip?: string;
    buildOptions?: (validationService: ValidatorService) => any;
    controlAccessor?: (control: ControlComponent) => void;
    formAccessor?: (form: FormGroup) => void;
}

export enum ControlType {
    Input = 'input',
    Text = 'text',
    SingleSelect = 'select',
    MultiSelect = 'multi_select',
    Checkbox = 'checkbox',
    Number = 'number'
}