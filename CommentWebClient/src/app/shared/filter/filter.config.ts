export interface FilterConfig {
    filter?: string;
    filters?: IFilter[];
    onClear?: () => void;
    onApply?: (filter: string) => void;
}

export interface IFilter {
    label: string;
    field: string;
    type: string;
    active?: boolean;
    value?: any;
    operator?: string;
    operators?: { value: string, label: string }[];
    options?: any[];
}

export const getFilterString = (config: FilterConfig) => {
    let filter = '';
    const filters: string[] = [];
    if (config?.filter) {
        filters.push(config.filter);
    }
    if (config?.filters) {
        config.filters.forEach(x => {
            if (x.active && x.value) {
                let _filter = `${x.field} ${x.operator} `;
                let value: string = null;
                if (x.type == "date" && x.value.constructor.name == "Date") {
                    value = `${x.value.toISOString()}`;
                }
                else {
                    value = `${x.value}`;
                }
                if (value) {
                    if (value.includes(' ')) {
                        value = `"${value}"`;
                    }
                    filters.push(`${_filter}${value}`);
                }
            }
        });
    }
    if (filters) {
        filter = filters.join(' and ');
    }
    return filter;
}