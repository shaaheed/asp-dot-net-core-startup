import { Routes } from '@angular/router';
import { Column } from 'src/app/shared/table2/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'units';

export const UNIT_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.namex(),
                Column.column('symbol'),
                Column.column('type', x => x.type?.name),
                // Column.column('parent.unit', x => x.baseUnit?.)
                Column.created()
            ]
        }),
        ...[
            { path: `${prefix}/create`, loadChildren: () => import('./add/units-add.module').then(x => x.UnitsAddModule) },
            { path: `${prefix}/:id/edit`, loadChildren: () => import('./add/units-add.module').then(x => x.UnitsAddModule) }
        ]
    ]
}