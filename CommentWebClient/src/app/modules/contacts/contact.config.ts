import { FormGroup } from '@angular/forms';
import { Routes } from '@angular/router';
import { Column } from 'src/services/column.service';
import { Control } from 'src/services/control.service';
import { Route } from 'src/services/route.service';
import { CURRENCY } from '../organizations/organization.service';

export const CONTACT_CONFIG = {
    ROUTES: (prefix: string, objectName: string, type: number) => {
        return <Routes>[
            Route.list(prefix, {
                fetchApiUrl: `contacts?Search=Type eq ${type}`,
                getDeleteApiUrl: x => `contacts/${x.id}`,
                tableColumns: [
                    Column.column('name', x => x.displayName),
                    Column.column('mobile'),
                    Column.column('email'),
                    Column.column('address'),
                    Column.column('total.due', x => `${CURRENCY}${x.totalDueAmount}`),
                    Column.created()
                ]
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
                onSetFormValues: (data: any, form: FormGroup) => {
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