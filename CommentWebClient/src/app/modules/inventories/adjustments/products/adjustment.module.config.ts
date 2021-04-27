import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'inventories/adjustments';

export const INVENTORY_ADJUSTMENT_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            pageTitle: 'inventory.adjustment',
            tableColumns: [
                Column.date('date', x => x.adjustmentDate ?? '—'),
                Column.column('reference', x => x.reference ?? '—'),
                Column.column('status', x => x.status),
                Column.column('reason', x => x.reason ?? '—'),
                Column.created()
            ]
        }),
        {
            path: `${prefix}/create`,
            loadChildren: () => import('./add/adjustments-add.module').then(x => x.InventoryAdjustmentAddModule)
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('./add/adjustments-add.module').then(x => x.InventoryAdjustmentAddModule)
        }
    ]
}