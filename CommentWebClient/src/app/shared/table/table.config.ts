import { Observable } from 'rxjs';
import { ButtonConfig } from '../button.config';

export interface TableConfig {
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