import { ChangeDetectionStrategy, Component, Input, NgModule, TemplateRef, ViewChild } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { NzIconModule } from 'ng-zorro-antd/icon';

@Component({
    selector: 'app-table-row',
    template:  `
    <ng-template #template let-data="data">
        {{log(data)}}
        <ng-content></ng-content>
    </ng-template>
    `,
    changeDetection: ChangeDetectionStrategy.OnPush
  })
  export class TableRowComponent {
    
    @Input() public label: string;
    @Input() public data: any;
    @ViewChild('template', {static : true}) template: TemplateRef<any>;

    constructor() {
      console.log(new Date().getTime());
    }

    log(e) {
      console.log(e);
    }
  
  }

  @NgModule({
    declarations: [
        TableRowComponent
    ],
    exports: [
        TableRowComponent
    ],
    imports: [
      NzIconModule,
      TranslateModule
    ]
  })
  export class TableRowModule {

  }