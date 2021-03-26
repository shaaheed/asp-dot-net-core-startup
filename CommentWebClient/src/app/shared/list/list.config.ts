import { TableConfig } from '../table/table.config';

export interface ListPageConfig extends TableConfig {
    tableColumns?: TableColumnConfig[];
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