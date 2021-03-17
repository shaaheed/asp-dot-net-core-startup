import { Route, Routes } from "@angular/router"
import { AppInjector } from "src/app/app.component";
import { FormPageConfig } from "src/app/shared/form-page/form.config"
import { ListPageConfig, TableColumnConfig } from "src/app/shared/list/list.config";
import { MomentPipe } from "src/pipes/moment.pipe";
import { TimeAgoPipe } from "src/pipes/time-ago.pipe";

export function createAddEditRoutes(prefix: string, config: FormPageConfig): Routes {
    config.apiUrl = config.apiUrl || prefix;
    config.cancelRoute = config.cancelRoute || prefix;
    return [
        {
            path: `${prefix}/create`,
            loadChildren: () => import('src/app/shared/form-page/form.module').then(x => x.FormPageModule),
            data: {
                pageData: config
            }
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('src/app/shared/form-page/form.module').then(x => x.FormPageModule),
            data: {
                pageData: config
            }
        }
    ]
}

export function createListPageRoute(prefix: string, config: ListPageConfig): Route {
    config.pageTitle = config.pageTitle || prefix;
    config.fetchApiUrl = config.fetchApiUrl || prefix;
    if (!config.getDeleteApiUrl) {
        config.getDeleteApiUrl = data => `${prefix}/${data.id}`;
    }
    config.createPageRoute = config.createPageRoute || `${prefix}/create`;
    if (!config.editPageRoute) {
        config.editPageRoute = data => `${prefix}/${data.id}/edit`;
    }
    return {
        path: prefix,
        loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
        data: {
            pageData: config
        }
    }
}

export function createListPageCreatedColumn(): TableColumnConfig {
    return {
        title: 'created',
        tdClass: 'fit-cell',
        hasToolTip: true,
        getCellToolTipData: data => AppInjector.get(MomentPipe).transform(data.createdAt),
        getCellData: data => AppInjector.get(TimeAgoPipe).transform(data.createdAt)
    }
}