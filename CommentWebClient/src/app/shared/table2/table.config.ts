import { Observable } from 'rxjs';
import { ButtonConfig } from '../button.config';

export interface TableConfig {
    tableColumns?: TableColumnConfig[];
    pageTitle?: string;
    createPageRoute?: string;
    onClickButton?: (source: any) => void;
    editPageRoute?: (data?: any) => string;
    fetch?: (pagination: string, search?: string) => Observable<Object>;
    fetchApiUrl?: string;
    getFetchApiUrl?: (data?: any) => string;
    /**
    * Provide delete API.
    */
    getDeleteApiUrl?: (data: any) => string;
    topRightButtons?: ButtonConfig[];
    headerStyle?: any;
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