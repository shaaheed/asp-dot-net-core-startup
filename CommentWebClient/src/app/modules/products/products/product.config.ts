import { Routes } from '@angular/router';
import { Filter } from 'src/app/shared/filter/filter';
import { Column } from 'src/app/shared/table2/column.service';
import { Route } from 'src/services/route.service';
import { CURRENCY } from '../../organizations/organization.service';

const prefix = 'products';

export const PRODUCT_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.namex(),
                Column.column('price', x => x.salesPrice ? `${CURRENCY} ${x.salesPrice} ${x.salesUnit ? `/${x.salesUnit.code}` : ''}` : '—'),
                Column.column('quantity', x => `${x.stockQuantity} ${x.salesUnit ? x.salesUnit.code : ''}` ?? '—'),
                Column.created()
            ],
            filterConfig: {
                filters: [
                    Filter.text('name', 'Name'),
                    Filter.number('price', 'SalesPrice'),
                    Filter.number('quantity', 'StockQuantity')
                ]
            }
        }),
        Route.list(`${prefix}/transactions`, {
            fetchApiUrl: `${prefix}/transactions`,
            pageTitle: 'product.transactions',
            tableColumns: [
                Column.column('type', x => x.type),
                Column.column('name', x => x.product?.name),
                Column.column('reference', x => x.reference?.name),
                Column.column('quantity', x => `${x.quantity} ${x.unit ? x.unit.name : ''}` ?? '—'),
                Column.column('price', x => x.unitPrice),
                Column.column('total', x => (x.unitPrice * x.quantity).toString()),
                Column.created()
            ],
            filterConfig: {
                filters: [
                    Filter.text('name', 'Name'),
                    Filter.text('reference', 'Reference'),
                    Filter.number('quantity', 'Quantity'),
                    Filter.number('price', 'UnitPrice')
                ]
            }
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