import { Routes } from '@angular/router';
import { Column } from 'src/app/shared/table2/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'terms';

export const TERM_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.namex(),
                Column.column('days', x => x.days),
                Column.created(),
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'terms',
            controls: [
                Control.namex(),
                Control.number('days', 'days', true)
            ]
        }),
    ]
}