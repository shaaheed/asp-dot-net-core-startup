import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';

const prefix = 'users';

export const USER_MODULE_CONFIG = {
    ROUTES: <Routes>[
        {
            path: prefix,
            loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
            data: {
                pageData: <ListPageConfig>{
                    pageTitle: prefix,
                    fetchUrl: prefix,
                    createPageRoute: `${prefix}/create`,
                    editPageRoute: data => `${prefix}/${data.id}/edit`,
                    tableColumns: [
                        {
                            title: 'name',
                            getCellData: data => data.firstName
                        },
                        {
                            title: 'email',
                            getCellData: data => data.email
                        },
                        {
                            title: 'mobile',
                            getCellData: data => data.mobile
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
            loadChildren: () => import('./add/users-add.module').then(x => x.UsersAddModule)
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('./add/users-add.module').then(x => x.UsersAddModule)
        }
    ]
}