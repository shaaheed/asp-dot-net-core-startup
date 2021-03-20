import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'invoices';

export const INVOICE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.column('number'),
                Column.column('customer', x => x.customer?.name),
                Column.column('due', x => x.amountDue),
                Column.column('total'),
                Column.column('date', x => x.issueDate),
                Column.created()
            ]
        }),
        { path: `${prefix}/create`, loadChildren: () => import('./add/invoices-add.module').then(x => x.InvoicesAddModule) },
        { path: `${prefix}/:id/edit`, loadChildren: () => import('./add/invoices-add.module').then(x => x.InvoicesAddModule) },
        { path: `${prefix}/:id`, loadChildren: () => import('./home/invoice-home.module').then(x => x.InvoiceHomeModule) }
    ]
}