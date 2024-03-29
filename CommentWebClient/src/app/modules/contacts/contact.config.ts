import { UntypedFormGroup } from '@angular/forms';
import { Routes } from '@angular/router';
import { Filter } from 'src/app/shared/filter/filter';
import { Column } from 'src/app/shared/table2/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';
import { CURRENCY } from '../organizations/organization.service';

export const CONTACT_CONFIG = {
    ROUTES: (prefix: string, objectName: string, type: number) => {
        return <Routes>[
            Route.list(prefix, {
                fetchApiUrl: `contacts`,
                getDeleteApiUrl: x => `contacts/${x.id}`,
                tableColumns: [
                    Column.column('name', x => x.displayName),
                    Column.column('mobile'),
                    Column.column('email'),
                    Column.column('address'),
                    Column.column('total.due', x => `${CURRENCY}${x.totalDueAmount}`),
                    Column.created()
                ],
                filterConfig: {
                    filter: `Type eq ${type}`,
                    filters: [
                        Filter.text('name', 'DisplayName'),
                        Filter.text('mobile', 'Mobile'),
                        Filter.text('email', 'Email')
                    ]
                }
            }),
            ...Route.addEdit(prefix, {
                objectName: objectName,
                apiUrl: 'contacts',
                onBeforeSubmit: data => {
                    if (data) {
                        data.type = type;
                        data.billingAddress = {
                            addressLine1: data.address
                        }
                    }
                },
                onSetFormValues: (data: any, form: UntypedFormGroup) => {
                    if (data?.billingAddress) {
                        form.controls.address.setValue(data.billingAddress.addressLine1);
                    }
                },
                controls: [
                    Control.input('displayName', 'name', true),
                    Control.input('mobile'),
                    Control.input('email'),
                    Control.text('address'),
                ]
            })
        ]
    }
}