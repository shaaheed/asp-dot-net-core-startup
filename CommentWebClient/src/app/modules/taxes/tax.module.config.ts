import { Routes } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AppInjector } from 'src/app/app.component';
import { ControlType, InputConfig } from 'src/app/shared/form-page/control.config';
import { text } from 'src/constants/text';
import { MomentPipe } from 'src/pipes/moment.pipe';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';
import { createAddEditRoutes, createListPageRoute } from 'src/services/page.service';
import { ValidatorService } from 'src/services/validator.service';

const prefix = 'taxes';

const taxNumber = 'tax.number';
const taxRate = 'tax.rate%';

export const TAX_MODULE_CONFIG = {
    ROUTES: <Routes>[
        createListPageRoute(prefix, {
            tableColumns: [
                {
                    title: text.name,
                    getCellData: data => data.isCompoundTax ? `${data.name} (${AppInjector.get(TranslateService).instant('compound.tax')})` : data.name
                },
                {
                    title: taxRate,
                    getCellData: data => `${data.rate}%`
                },
                {
                    title: 'created',
                    tdClass: 'fit-cell',
                    hasToolTip: true,
                    getCellToolTipData: data => AppInjector.get(MomentPipe).transform(data.createdAt),
                    getCellData: data => AppInjector.get(TimeAgoPipe).transform(data.createdAt)
                }
            ]
        }),
        ...createAddEditRoutes(prefix, {
            objectName: 'tax',
            controls: [
                {
                    name: text.name,
                    label: text.name,
                    controlType: ControlType.Input,
                    placeholder: text.name,
                    buildOptions: (validator: ValidatorService) => {
                        return [null, [], [
                            validator.required()
                        ]];
                    }
                },
                {
                    name: text.description,
                    label: text.description,
                    controlType: ControlType.Text,
                    placeholder: text.description
                },
                {
                    name: 'taxNumber',
                    label: taxNumber,
                    controlType: ControlType.Input,
                    placeholder: taxNumber
                },
                <InputConfig>{
                    name: 'rate',
                    label: taxRate,
                    controlType: ControlType.Input,
                    placeholder: taxRate,
                    type: 'number',
                    buildOptions: (validator: ValidatorService) => {
                        return [null, [], [
                            validator.required()
                        ]];
                    }
                },
                {
                    name: 'isCompound',
                    label: 'this.is.a.compound.tax',
                    controlType: ControlType.Checkbox,
                    tooltip: 'compound.tax.tooltip'
                },
            ]
        })
    ]
}