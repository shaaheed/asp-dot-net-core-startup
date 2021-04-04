import { Router, Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { Column } from 'src/services/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'invoices';

export const INVOICE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.column('number', x => x.code, x => {
                    AppInjector.get(Router).navigateByUrl(`invoices/${x.id}`);
                }),
                Column.column('customer', x => x.customer?.name),
                Column.column('due', x => x.amountDue),
                Column.column('total'),
                Column.date('date', x => AppInjector.get(MomentPipe).transform( x.issueDate)),
                Column.created()
            ]
        }),
        { path: `${prefix}/create`, loadChildren: () => import('./add/invoices-add.module').then(x => x.InvoicesAddModule) },
        { path: `${prefix}/:id/edit`, loadChildren: () => import('./add/invoices-add.module').then(x => x.InvoicesAddModule) },
        { path: `${prefix}/:id`, loadChildren: () => import('./view/invoices-view.module').then(x => x.InvoicesViewModule) }
    ]
}