import { Routes } from '@angular/router';
import { InvoicesAddComponent } from '../invoices/add/invoices-add.component';
import { makeListRoute } from '../invoices/invoice.config';
import { InvoicesViewComponent } from '../invoices/view/invoices-view.component';

const prefix = 'bills';
const objectName = 'bill';
const contactTitle = 'supplier';

const addEditData = {
    componentAccessor: (c: InvoicesAddComponent) => {
        c.apiUrl = prefix;
        c.objectName = objectName;
        c.contactTitle = contactTitle;
        c.contactApiUrl = 'contacts';
        c.chooseAnotherTitle = 'choose.a.different.supplier';
        c.createInfoUrl = `${prefix}/create-info`;
        c.getNextNumber = x => x.nextBillNumber;
        c.dateLabel = 'bill.date';
        c.onGetData = (data: any) => {
            if (c.isEditMode() && c.contactAutocomplete && data) {
                // c.contactAutocomplete.value = data.supplier.displayName;
                // c.contactSelect.item = data.supplier;
                // c.contactSelect.select.value = data.supplier?.id;
            }
        }
    }
}

const viewData = {
    componentAccessor: (c: InvoicesViewComponent) => {
        c.apiUrl = prefix;
        c.contactTitle = contactTitle;
        c.objectName = objectName;
        c.onGetData = data => {
            c.contact = data?.contact;
        }
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
            data: addEditData,
            loadChildren: () => import('../invoices/add/invoices-add.module').then(x => x.InvoicesAddModule)
        },
        {
            path: `${prefix}/:id`,
            data: viewData,
            loadChildren: () => import('../invoices/view/invoices-view.module').then(x => x.InvoicesViewModule)
        }
    ]
}