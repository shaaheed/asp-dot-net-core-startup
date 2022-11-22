import { Routes } from '@angular/router';
import { map } from 'rxjs/operators';
import { AppInjector } from 'src/app/app/app.component';
import { ControlType, SelectConfig } from 'src/app/shared/form-page/control.config';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { Column } from 'src/app/shared/table2/column.service';
import { Control } from 'src/services/control.service';
import { HttpService } from 'src/services/http/http.service';
import { Route } from 'src/services/route.service';
import { ORGANIZATION_ID } from '../organization.service';

const prefix = `organizations/:organizationId/currencies`;

export const ORGANIZATION_CURRENCY_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            pageTitle: 'currencies',
            createPageRoute: x => `organizations/${ORGANIZATION_ID}/currencies/create`,
            editPageRoute: x => `organizations/${ORGANIZATION_ID}/currencies/${x.id}/edit`,
            fetchApiUrl: x => {
                console.log('x', x, ORGANIZATION_ID);
                return `organizations/${ORGANIZATION_ID}/currencies`;
            },
            tableColumns: [
                Column.column('currency', x => `${x.currency.code} (${x.currency.name})`)
            ]
        }),
        ...Route.addEdit(prefix, {
            objectName: 'currency',
            apiUrl: `organizations/${ORGANIZATION_ID}/currencies`,
            controls: [
                <SelectConfig>{
                    name: 'currencyId',
                    label: 'currency',
                    controlType: ControlType.SingleSelect,
                    controlAccessor: (accessor: SelectControlComponent) => accessor.register((pagination, search) => {
                        return AppInjector.get(HttpService).get('systems/currencies?offset=0&limit=165')
                            .pipe(
                                map((x: any) => {
                                    if (x?.data?.items) {
                                        x.data.items.forEach(item => {
                                            item.name = `${item.code} (${item.name})`;
                                        });
                                    }
                                    return x;
                                })
                            );
                    })
                },
                Control.input('exchangeRate', 'exchange.rate'),
            ]
        })
    ]
}