import { Routes } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { map } from 'rxjs/operators';
import { AppInjector } from 'src/app/app/app.component';
import { ControlType, SelectConfig } from 'src/app/shared/form-page/control.config';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { HttpService } from 'src/services/http/http.service';
import { Route } from 'src/services/route.service';

const prefix = 'organizations';

export const ORGANIZATION_CONFIG = {
    ROUTES: <Routes>[
        Route.list(prefix, {
            tableColumns: Column.nameCreated()
        }),
        ...Route.addEdit(prefix, {
            objectName: 'organization',
            controls: [
                Control.namex(),
                Control.input('owner', 'owner'),
                Control.input('mobile', 'mobile'),
                Control.input('email', 'email'),
                Control.text('address', 'address'),
                <SelectConfig>{
                    name: 'currencyId',
                    label: 'currency',
                    controlType: ControlType.SingleSelect,
                    info: x => AppInjector.get(TranslateService).instant('organization.currency.select.info'),
                    controlAccessor: (accessor: SelectControlComponent) => accessor.register((pagination, search) => {
                        return AppInjector.get(HttpService).get('systems/currencies?offset=0&limit=165')
                        .pipe(
                            map((x: any) => {
                                if (x?.data?.items) {
                                    x.data.items.forEach(item => {
                                        item.name = `${item.code} - ${item.name} (${item.symbol})`;
                                    });
                                }
                                return x;
                            })
                        );
                    })
                },
            ]
        })
    ]
}