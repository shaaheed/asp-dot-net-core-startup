import { IFilter } from "./filter.config";

export class Filter {
    static text(label: string, field: string): IFilter {
        return Filter.create(label, field, 'text');
    }

    static number(label: string, field: string): IFilter {
        return Filter.create(label, field, 'number');
    }

    static date(label: string, field: string): IFilter {
        return Filter.create(label, field, 'date');
    }

    static create(label: string, field: string, type: string): IFilter {
        return {
            label: label,
            field: field,
            type: type
        };
    }
}