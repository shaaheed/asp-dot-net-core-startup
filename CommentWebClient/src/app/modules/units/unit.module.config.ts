import { Routes } from '@angular/router';
import { AppInjector } from 'src/app/app.component';
import { ControlType } from 'src/app/shared/form-page/control.config';
import { ListPageConfig } from 'src/app/shared/list/list.config';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { text } from 'src/constants/text';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';
import { HttpService } from 'src/services/http/http.service';
import { createAddEditRoutes } from 'src/services/page.service';
import { ValidatorService } from 'src/services/validator.service';

const prefix = 'units';
const symbol = 'symbol';

export const UNIT_MODULE_CONFIG = {
    ROUTES: <Routes>[
        {
            path: prefix,
            loadChildren: () => import('src/app/shared/list/list.module').then(m => m.ListModule),
            data: {
                pageData: <ListPageConfig>{
                    pageTitle: prefix,
                    fetchApiUrl: prefix,
                    getDeleteApiUrl: data => `${prefix}/${data.id}`,
                    createPageRoute: `${prefix}/create`,
                    editPageRoute: data => `${prefix}/${data.id}/edit`,
                    tableColumns: [
                        {
                            title: 'name',
                            getCellData: data => data.name
                        },
                        {
                            title: 'symbol',
                            getCellData: data => data.symbol
                        },
                        {
                            title: 'type',
                            getCellData: data => data.type?.name
                        },
                        {
                            title: 'created',
                            tdClass: 'fit-cell',
                            hasToolTip: true,
                            getCellToolTipData: data => AppInjector.get(MomentPipe).transform(data.createdAt),
                            getCellData: data => AppInjector.get(TimeAgoPipe).transform(data.createdAt)
                        }
                    ]
                }
            }
        },
        ...createAddEditRoutes(prefix, {
            objectName: 'unit',
            controls: [
                {
                    name: text.name,
                    label: text.name,
                    controlType: ControlType.Input,
                    placeholder: text.name,
                    buildOptions: (validator: ValidatorService) => {
                        return [null, [], [
                            validator.required(),
                            validator.min(2)
                        ]];
                    }
                },
                {
                    name: symbol,
                    label: symbol,
                    controlType: ControlType.Input,
                    placeholder: symbol,
                    buildOptions: (validator: ValidatorService) => {
                        return [null, [], [
                            validator.required()
                        ]];
                    }
                },
                {
                    name: 'typeId',
                    label: 'type',
                    controlType: ControlType.SingleSelect,
                    placeholder: 'type',
                    buildOptions: (validator: ValidatorService) => {
                        return [null, [], [
                            validator.required()
                        ]];
                    },
                    controlAccessor: (control: SelectControlComponent) => {
                        control.register((pagination, search) => {
                            return AppInjector.get(HttpService).get('units/types');
                        });
                    }
                },
                {
                    name: text.description,
                    label: text.description,
                    controlType: ControlType.Text,
                    placeholder: text.description
                },
            ]
        })
    ]
}