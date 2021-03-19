import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'products/categories';

export const CATEGORY_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            pageTitle: 'product.categories',
            tableColumns: Column.nameCreated()
        }),
        ...Route.addEdit(prefix, {
            objectName: 'product.category',
            controls: [Control.namex()]
        }),
    ]
}