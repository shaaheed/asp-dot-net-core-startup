export interface InputConfig extends ControlConfig {
    type: string;
    suffix: string;
    prefix: string;
}

export interface ControlConfig {
    name: string;
    controlType: ControlType;
    label: string;
    placeholder: string;
    onChange: (value: any) => void;
    mandatory: boolean;
    tooltip: string;
    validations: []
}

export enum ControlType {
    Input = 'name',
    Text = 'text',
    SingleSelect = 'select',
    MultiSelect = 'multi_select',
    Checkbox = 'checkbox',
    Number = 'number'
}