import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';

const urlPrefix = 'organizations';

export const ORGANIZATION_CONFIG = {
    ROUTES: <Routes>[
        {
            path: urlPrefix,
            loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
            data: {
                pageData: <ListPageConfig>{
                    pageTitle: urlPrefix,
                    fetchApiUrl: urlPrefix,
                    getDeleteApiUrl: data => `${urlPrefix}/${data.id}`,
                    createPageRoute: `${urlPrefix}/create`,
                    editPageRoute: data => `${urlPrefix}/${data.id}/edit`,
                    tableColumns: [
                        {
                            title: 'name',
                            getCellData: data => {
                                console.log('cell data', data);
                                return data.name
                            }
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
            path: `${urlPrefix}/create`,
            loadChildren: () => import('./add/organization-add.module').then(x => x.OrganizationAddModule)
        },
        {
            path: `${urlPrefix}/:id/edit`,
            loadChildren: () => import('./add/organization-add.module').then(x => x.OrganizationAddModule)
        }
    ]
}