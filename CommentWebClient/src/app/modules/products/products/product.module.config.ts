import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'products';

export const PRODUCT_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.namex(),
                Column.column('price', x => x.salesPrice ? `৳ ${x.salesPrice} ${x.salesUnit ? `/ ${x.salesUnit.name}` : ''}` : '—'),
                Column.column('quantity', x => x.stockQuantity ?? '—'),
                Column.created()
            ]
        }),
        {
            path: `${prefix}/create`,
            loadChildren: () => import('./add/products-add.module').then(x => x.ProductsAddModule)
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('./add/products-add.module').then(x => x.ProductsAddModule)
        }
    ]
}