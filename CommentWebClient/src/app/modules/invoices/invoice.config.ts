import { Router, Routes } from '@angular/router';
import { AppInjector } from 'src/app/app/app.component';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { Column } from 'src/services/column.service';
import { Route } from 'src/services/route.service';
import { CURRENCY } from '../organizations/organization.service';

const prefix = 'invoices';

export const makeListRoute = (prefix: string, contactTitle: string): Route => {
    return Route.list(prefix, {
        tableColumns: [
            Column.column('number', x => x.code, x => {
                AppInjector.get(Router).navigateByUrl(`${prefix}/${x.id}`);
            }),
            Column.column(contactTitle, x => x[contactTitle]?.name),
            Column.column('due', x => {
                return `${CURRENCY} ${x.amountDue}`
            }),
            Column.column('payments', x => {
                if (!isNaN(x.total) && !isNaN(x.amountDue)) {
                    return `${CURRENCY} ${x.total - x.amountDue}`;
                }
                return '-';
            }),
            Column.column('total', x => {
                return `${CURRENCY} ${x.total}`
            }),
            Column.date('date', x => AppInjector.get(MomentPipe).transform(x.issueDate)),
            Column.created()
        ]
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