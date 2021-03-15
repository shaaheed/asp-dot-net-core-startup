import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';

const prefix = 'products/categories';

export const CATEGORY_MODULE_CONFIG = {
    ROUTES: <Routes>[
        {
            path: prefix,
            loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
            data: {
                pageData: <ListPageConfig>{
                    pageTitle: 'product.categories',
                    fetchApiUrl: prefix,
                    getDeleteApiUrl: data => `${prefix}/${data.id}`,
                    createPageRoute: `${prefix}/create`,
                    editPageRoute: data => `${prefix}/${data.id}/edit`,
                    tableColumns: [
                        {
                            title: 'name',
                            getCellData: data => data.name
                        },
                        {
                            title: 'created',
                            tdClass: 'fit-cell',
                            hasToolTip: true,
                            getCellToolTipData: data => AppInjector.get(MomentPipe).transform(data.createdAt),
                            getCellData: data => AppInjector.get(TimeAgoPipe).transform(data.createdAt)
                        }
                    ]
                }
            }
        },
        {
            path: `${prefix}/create`,
            loadChildren: () => import('./add/categories-add.module').then(x => x.CategoriesAddModule)
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('./add/categories-add.module').then(x => x.CategoriesAddModule)
        }
    ]
}