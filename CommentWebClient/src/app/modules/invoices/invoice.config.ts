import { Router, Routes } from '@angular/router';
import { AppInjector } from 'src/app/app/app.component';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { Column } from 'src/app/shared/table2/column.service';
import { Route } from 'src/services/route.service';
import { CURRENCY } from '../organizations/organization.service';
import { Filter } from 'src/app/shared/filter/filter';

const prefix = 'invoices';

export const makeListRoute = (prefix: string, contactTitle: string): Route => {
    return Route.list(prefix, {
        tableColumns: [
            Column.column('number', x => x.number, x => {
                AppInjector.get(Router).navigateByUrl(`${prefix}/${x.id}`);
            }),
            Column.column(contactTitle, x => x[contactTitle]?.name),
            Column.column('due', x => {
                return `${CURRENCY} ${x.amountDue}`
            }),
            Column.column('total', x => {
                return `${CURRENCY} ${x.total}`
            }),
            Column.date('date', x => AppInjector.get(MomentPipe).transform(x.issueDate)),
            Column.created()
        ],
        filterConfig: {
            filters: [
                Filter.text('number', 'Number'),
                Filter.number('due', 'AmountDue'),
                Filter.number('total', 'GrandTotal')
            ]
        }
    })
}

export const INVOICE_CONFIG = {
    ROUTES: <Routes>[
        makeListRoute(prefix, 'customer'),
        { path: `${prefix}/create`, loadChildren: () => import('./add/invoices-add.module').then(x => x.InvoicesAddModule) },
        { path: `${prefix}/:id/edit`, loadChildren: () => import('./add/invoices-add.module').then(x => x.InvoicesAddModule) },
        { path: `${prefix}/:id`, loadChildren: () => import('./view/invoices-view.module').then(x => x.InvoicesViewModule) }
    ]
}