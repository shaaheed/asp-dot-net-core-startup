import { ControlConfig } from './control.config';

export interface FormPageConfig {
    apiUrl?: string;
    cancelRoute?: string;
    objectName: string;
    rows?: FormRowConfig[];
    controls?: ControlConfig[];
    onBeforeSubmit?: (data?: any) => void;
}

export interface FormColumnConfig {
    span?: number;
    controls?: ControlConfig[];
}

export interface FormRowConfig {
    columns?: FormColumnConfig[];
}