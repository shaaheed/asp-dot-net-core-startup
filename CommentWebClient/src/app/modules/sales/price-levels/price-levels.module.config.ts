import { Routes } from '@angular/router';
import { Column } from 'src/app/shared/table2/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'priceLevels';

export const PRICE_LEVEL_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            pageTitle: 'price.levels',
            tableColumns: [
                ...Column.nameCreated(),
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'price.levels',
            controls: [
                Control.namex(),
            ]
        }),
    ]
}