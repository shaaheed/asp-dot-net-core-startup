import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'organizations';

export const ORGANIZATION_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: Column.nameCreated()
        }),
        ...Route.addEdit(prefix, {
            objectName: 'organization',
            controls: [Control.namex()]
        })
    ]
}