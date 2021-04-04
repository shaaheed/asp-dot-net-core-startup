import { Pipe, PipeTransform, NgModule } from '@angular/core';
import * as moment from 'moment';

@Pipe({ name: 'momentDate' })
export class MomentPipe implements PipeTransform {
    transform(value: Date | moment.Moment, args?: any): any {
        if(value) {
            const format = args || 'MMMM D, YYYY, h:mm:ss A';
            return moment.utc(value).local().format(format);
        }
        return '';
    }
}

@NgModule({
    declarations: [MomentPipe],
    exports: [MomentPipe],
    providers: [MomentPipe]
})
export class MomentPipeModule { }