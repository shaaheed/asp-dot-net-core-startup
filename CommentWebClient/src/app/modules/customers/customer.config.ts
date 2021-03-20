import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'customers';

export const CUSTOMER_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            fetchApiUrl: 'contacts?Search=Type eq 1',
            getDeleteApiUrl: x => `contacts/${x.id}`,
            tableColumns: [
                Column.column('name', x => x.displayName),
                Column.column('mobile'),
                Column.column('email'),
                Column.created()
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'customer',
            apiUrl: 'contacts',
            onBeforeSubmit: data => {
                if (data) {
                    data.type = 1;
                }
            },
            controls: [
                Control.input('displayName', 'name', true),
                Control.input('mobile'),
                Control.input('email'),
            ]
        })
    ]
}