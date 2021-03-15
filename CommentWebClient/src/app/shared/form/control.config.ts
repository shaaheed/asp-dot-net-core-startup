export interface InputConfig extends ControlConfig {
    type: string;
    suffix: string;
    prefix: string;
}

export interface ControlConfig {
    controlType: ControlType;
    label: string;
    placeholder: string;
    onChange: (value: any) => void;
    mandatory: boolean;
    tooltip: string;
}

export enum ControlType {
    Input,
    Text,
    SingleSelect,
    MultiSelect
}