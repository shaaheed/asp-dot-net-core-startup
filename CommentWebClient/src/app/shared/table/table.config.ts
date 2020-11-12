import { Observable } from 'rxjs';
import { ButtonConfig } from '../button.config';

export interface TableConfig {
    pageTitle?: string;
    createPageRoute?: string;
    editPageRoute?: (data?: any) => string;
    fetch?: (pagination: string, search?: string) => Observable<Object>;
    fetchUrl?: string;
    topRightButtons?: ButtonConfig[];
}