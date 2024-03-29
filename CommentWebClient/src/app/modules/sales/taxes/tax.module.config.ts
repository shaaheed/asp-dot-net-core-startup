import { Routes } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AppInjector } from 'src/app/app/app.component';
import { Column } from 'src/app/shared/table2/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'taxes';
const taxNumber = 'tax.number';
const taxRate = 'tax.rate%';

export const TAX_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.column('name', x => x.isCompoundTax ? `${x.name} (${AppInjector.get(TranslateService).instant('compound.tax')})` : x.name),
                Column.column(taxRate, d => `${d.rate}%`),
                Column.created()
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'tax',
            controls: [
                Control.namex(),
                Control.description(),
                Control.input('taxNumber', taxNumber),
                Control.number('rate', taxRate, true),
                Control.checkbox('isCompound', 'this.is.a.compound.tax', 'compound.tax.tooltip')
            ]
        })
    ]
}