export interface FilterConfig {
    filters?: Filter[];
    onClear?: () => void;
    onApply?: (filter: string) => void;
}

export interface Filter {
    label: string;
    field: string;
    type: string;
    active: boolean;
    value?: any;
    operator?: string;
    operators?: {value: string, label: string}[];
    options?: any[];
}