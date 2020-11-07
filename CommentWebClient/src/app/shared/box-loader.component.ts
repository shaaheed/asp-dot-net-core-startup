import { Component, Input, NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { NzIconModule } from 'ng-zorro-antd/icon';

@Component({
    selector: 'app-box-loader',
    template:  `
    <div class="box box-loader no-shadow">
        <div class="block pad-v-12 pad-h-20 border-radius-5 box-loader-inner">
            <i nz-icon nzType="loading" style="font-size: 24px;"></i>
            <span style="padding-top: 5px;">{{'loading...'|translate}}</span>
        </div>
    </div>
    `
  })
  export class BoxLoaderComponent {
  
    @Input() loading: boolean = false;
    @Input() noData: boolean = false;
  
    constructor() {
    }
  
  }

  @NgModule({
    declarations: [
      BoxLoaderComponent
    ],
    exports: [
      BoxLoaderComponent
    ],
    imports: [
      NzIconModule,
      TranslateModule
    ]
  })
  export class BoxLoaderModule {

  }