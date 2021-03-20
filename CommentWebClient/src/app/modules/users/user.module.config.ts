import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'users';
const email = 'email';
const mobile = 'mobile';
const name = 'name';

export const USER_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.column(name, x => x.firstName),
                Column.column(email),
                Column.column(mobile),
                Column.created()
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'user',
            controls: [
                Control.input('firstName', name, true),
                Control.email(email, email, true),
                Control.input(mobile, mobile, true),
            ]
        }),
    ]
}