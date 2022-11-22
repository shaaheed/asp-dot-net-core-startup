import { Routes } from '@angular/router';
import { Column } from 'src/app/shared/table2/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'variants';

export const VARIATION_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                ...Column.nameCreated()
            ]
        }),
        ...[
            { path: `${prefix}/create`, loadChildren: () => import('./add/variations-add.module').then(x => x.VariationsAddModule) },
            { path: `${prefix}/:id/edit`, loadChildren: () => import('./add/variations-add.module').then(x => x.VariationsAddModule) }
        ]
    ]
}