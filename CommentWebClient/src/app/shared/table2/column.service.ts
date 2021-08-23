import { AppInjector } from "src/app/app/app.component";
import { TableColumnConfig } from "src/app/shared/table2/table.config";
import { MomentPipe } from "src/pipes/moment.pipe";
import { TimeAgoPipe } from "src/pipes/time-ago.pipe";

export class Column {

    static created(): TableColumnConfig {
        return {
            title: 'created',
            tdClass: 'fit-cell',
            hasToolTip: true,
            getCellToolTipData: data => AppInjector.get(MomentPipe).transform(data.createdAt),
            getCellData: data => AppInjector.get(TimeAgoPipe).transform(data.createdAt)
        }
    }

    static namex(): TableColumnConfig {
        return Column.column('name', d => d.name);
    }

    static description(): TableColumnConfig {
        return Column.column('description', d => d.description);
    }

    static nameCreated(): TableColumnConfig[] {
        return [
            Column.namex(),
            Column.created(),
        ]
    }

    static column(title: string, getCellData?: (data: any) => string, onClick?: (data: any) => void): TableColumnConfig {
        return {
            title: title,
            getCellData: getCellData || (x => x[title]),
            onClick: onClick
        }
    }

    static date(title: string, getCellData?: (data: any) => any): TableColumnConfig {
        return {
            title: title,
            getCellData: x => AppInjector.get(MomentPipe).transform(getCellData(x), 'MMM DD, YYYY'),
            hasToolTip: true,
            getCellToolTipData: x => AppInjector.get(MomentPipe).transform(getCellData(x))
        }
    }
}