import { IFilter } from "./filter.config";

export const eq = { value: 'eq', label: 'is equals to' };
export const ne = { value: 'ne', label: 'is not equals to' };
export const gt = { value: 'gt', label: 'is greater than' };
export const lt = { value: 'lt', label: 'is less than' };
export const ge = { value: 'ge', label: 'is greater than or equal to' };
export const le = { value: 'le', label: 'is less than or equal to' };
export const contains = { value: 'like', label: 'is contains' };
export const startsWith = { value: 'startsWith', label: 'is starts with' };
export const endsWith = { value: 'endsWith', label: 'is ends with' };
export const between = { value: 'between', label: 'is between' };

export const getOperators = (filter: IFilter): { value: string, label: string }[] => {
    const _type = filter.type?.toLocaleLowerCase();
    let operators: { value: string, label: string }[] = [];
    if (_type == 'text') {
        operators = [eq, ne, contains, startsWith, endsWith];
    }
    else if (_type == 'number') {
        operators = [eq, ne, gt, lt, ge, le];
    }
    else if (_type == 'date') {
        operators = [eq, ne, gt, lt, ge, le, between];
    }
    if (!filter.operator && operators) {
        filter.operator = operators[0].value;
    }
    return operators;
}