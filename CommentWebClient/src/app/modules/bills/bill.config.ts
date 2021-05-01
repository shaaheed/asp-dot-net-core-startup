import { Routes } from '@angular/router';
import { InvoicesAddComponent } from '../invoices/add/invoices-add.component';
import { makeListRoute } from '../invoices/invoice.config';

const prefix = 'bills';

const addEditData = {
    componentAccessor: (c: InvoicesAddComponent) => {
        c.apiUrl = 'bills';
        c.objectName = 'bill';
        c.contactTitle = 'supplier';
        c.contactApiUrl = 'contacts?Search=Type eq 2';
        c.chooseAnotherTitle = 'choose.a.different.supplier';
        c.createInfoUrl = 'bills/create-info';
        c.getNextNumber = x => x.nextBillNumber;
        c.dateLabel = 'bill.date';
    }
}

export const BILL_CONFIG = {
    ROUTES: <Routes>[
        makeListRoute(prefix, 'supplier'),
        {
            path: `${prefix}/create`,
            data: addEditData,
            loadChildren: () => import('../invoices/add/invoices-add.module').then(x => x.InvoicesAddModule)
        },
        {
            path: `${prefix}/:id/edit`,
            loadChildren: () => import('../invoices/add/invoices-add.module').then(x => x.InvoicesAddModule)
        },
        // { path: `${prefix}/:id`, loadChildren: () => import('./view/invoices-view.module').then(x => x.InvoicesViewModule) }
    ]
}