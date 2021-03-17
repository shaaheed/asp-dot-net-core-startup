import { Routes } from '@angular/router';
import { ControlType } from 'src/app/shared/form-page/control.config';
import { text } from 'src/constants/text';
import { createAddEditRoutes, createListPageCreatedColumn, createListPageRoute } from 'src/services/page.service';
import { ValidatorService } from 'src/services/validator.service';

const prefix = 'units/types';

export const UNIT_TYPE_MODULE_CONFIG = {
    ROUTES: <Routes>[
        createListPageRoute(prefix, {
            pageTitle: 'unit.types',
            tableColumns: [
                {
                    title: 'name',
                    getCellData: data => data.name
                },
                createListPageCreatedColumn()
            ]
        }),
        ...createAddEditRoutes(prefix, {
            objectName: 'unit.type',
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
                }
            ]
        })
    ]
}