import { Observable } from 'rxjs';
import { ButtonConfig } from '../button.config';
import { FilterConfig } from '../filter/filter.config';

export interface TableConfig {
    filterConfig?: FilterConfig,
    tableColumns?: TableColumnConfig[];
    pageTitle?: string;
    createPageRoute?: string | ((data?: any) => string);
    onClickButton?: (source: any) => void;
    editPageRoute?: (data?: any) => string;
    fetch?: (pagination: string, search?: string) => Observable<Object>;
    fetchApiUrl?: string | ((data?: any) => string);
    getDeleteApiUrl?: (data: any) => string;
    onRowDeleted?: (data: any) => void;
    topRightButtons?: ButtonConfig[];
    headerStyle?: any;
    boxStyle?: any;
}

export interface TableColumnConfig {
    type?: string;
    title: string;
    propertyName?: string;
    thClass?: string;
    tdClass?: string;
    hasToolTip?: boolean;
    getCellData?: (data?: any) => string;
    getCellToolTipData?: (data?: any) => string;
    onClick?: (data?: any) => void;
}