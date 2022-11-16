import { Routes } from '@angular/router';
import { Column } from 'src/app/shared/table2/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'units/types';

export const UNIT_TYPE_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            pageTitle: 'unit.types',
            tableColumns: [
                Column.namex(),
                Column.column('base.unit', x => x.baseUnit.name),
                Column.created(),
            ]
        }),
        ...[
            { path: `${prefix}/create`, loadChildren: () => import('./add/units-add.module').then(x => x.UnitsAddModule) },
            { path: `${prefix}/:id/edit`, loadChildren: () => import('./add/units-add.module').then(x => x.UnitsAddModule) }
        ]
    ]
}