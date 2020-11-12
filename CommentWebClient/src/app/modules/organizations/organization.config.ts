import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';

const org = 'organizations';

export const ORGANIZATION_CONFIG = {
    ROUTES: <Routes>[
        {
            path: org,
            loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
            data: {
                pageData: <ListPageConfig>{
                    pageTitle: org,
                    fetchUrl: org,
                    createPageRoute: `${org}/create`,
                    editPageRoute: data => `${org}/${data.id}/edit`,
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
            path: `${org}/create`,
            loadChildren: () => import('./add/organization-add.module').then(x => x.OrganizationAddModule)
        },
        {
            path: `${org}/:id/edit`,
            loadChildren: () => import('./add/organization-add.module').then(x => x.OrganizationAddModule)
        }
    ]
}