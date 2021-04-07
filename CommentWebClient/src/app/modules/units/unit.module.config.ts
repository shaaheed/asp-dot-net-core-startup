import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { HttpService } from 'src/services/http/http.service';
import { Control } from 'src/services/control.service';
import { Column } from 'src/services/column.service';
import { Route } from 'src/services/route.service';

const prefix = 'units';
const symbol = 'symbol';

export const UNIT_MODULE_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: [
                Column.namex(),
                Column.column('symbol'),
                Column.column('type', x => x.type?.name),
                // Column.column('parent.unit', x => x.baseUnit?.)
                Column.created()
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'unit',
            controls: [
                Control.namex(),
                Control.input(symbol, symbol, true),
                Control.select('typeId', 'type', true, accessor => accessor.register((pagination, search) => AppInjector.get(HttpService).get('units/types'))),
                Control.select('baseUnitId', 'parent.unit', false, accessor => accessor.register((pagination, search) => AppInjector.get(HttpService).get('units'))),
                Control.number('factor', 'conversion.factor'),
                Control.description()
            ]
        })
    ]
}