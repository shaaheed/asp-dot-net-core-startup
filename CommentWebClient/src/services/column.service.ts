import { AppInjector } from "src/app/app.component";
import { TableColumnConfig } from "src/app/shared/list/list.config";
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

    static column(title: string, getCellData?: (data: any) => string): TableColumnConfig {
        return {
            title: title,
            getCellData: getCellData || (x => x[title])
        }
    }

    static date(title: string, getCellData?: (data: any) => string): TableColumnConfig {
        return {
            title: title,
            getCellData: getCellData || (x => AppInjector.get(MomentPipe).transform(x[title]))
        }
    }
}