import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { ControlType } from 'src/app/shared/form-page/control.config';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { text } from 'src/constants/text';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';
import { createAddEditRoutes } from 'src/services/page.service';
import { ValidatorService } from 'src/services/validator.service';

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
        ...createAddEditRoutes(prefix, {
            objectName: 'product.category',
            controls: [
                {
                    name: text.name,
                    label: text.name,
                    controlType: ControlType.Input,
                    placeholder: text.name,
                    buildOptions: (validator: ValidatorService) => {
                        return [null, [], [
                            validator.required(),
                            validator.min(2)
                        ]];
                    }
                }
            ]
        })
    ]
}