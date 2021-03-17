import { Routes } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AppInjector } from 'src/app/app.component';
import { ControlType } from 'src/app/shared/form-page/control.config';
import { FormPageConfig } from 'src/app/shared/form-page/form.config';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';

const prefix = 'taxes';
const formPageConfig = <FormPageConfig>{
    apiUrl: prefix,
    cancelRoute: prefix,
    objectName: 'tax',
    controls: [
        {
            name: 'name',
            label: 'name',
            controlType: ControlType.Input,
            placeholder: 'name'
        },
        {
            name: 'description',
            label: 'description',
            controlType: ControlType.Text,
            placeholder: 'description'
        },
        {
            name: 'taxNumber',
            label: 'tax.number',
            controlType: ControlType.Input,
            placeholder: 'tax.number'
        },
        {
            name: 'rate',
            label: 'tax.rate%',
            controlType: ControlType.Number,
            placeholder: 'tax.rate%'
        },
        {
            name: 'isCompound',
            label: 'this.is.a.compound.tax',
            controlType: ControlType.Checkbox,
            tooltip: 'compound.tax.tooltip'
        },
    ]
};

export const TAX_MODULE_CONFIG = {
    ROUTES: <Routes>[
        {
            path: prefix,
            loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
            data: {
                pageData: <ListPageConfig>{
                    pageTitle: prefix,
                    fetchApiUrl: prefix,
                    getDeleteApiUrl: data => `${prefix}/${data.id}`,
                    createPageRoute: `${prefix}/create`,
                    editPageRoute: data => `${prefix}/${data.id}/edit`,
                    tableColumns: [
                        {
                            title: 'name',
                            getCellData: data => data.isCompoundTax ? `${data.name} (${AppInjector.get(TranslateService).instant('compound.tax')})` : data.name
                        },
                        {
                            title: 'tax.rate%',
                            getCellData: data => `${data.rate}%`
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
            loadChildren: () => import('src/app/shared/form-page/form.module').then(x => x.FormPageModule),
            data: {
                pageData: formPageConfig
            }
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('src/app/shared/form-page/form.module').then(x => x.FormPageModule),
        }
    ]
}