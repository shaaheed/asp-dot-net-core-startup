import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';

const prefix = 'units/types';

export const UNIT_TYPE_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            pageTitle: 'unit.types',
            tableColumns: Column.nameCreated()
        }),
        ...Route.addEdit(prefix, {
            objectName: 'unit.type',
            controls: [Control.namex()]
        })
    ]
}