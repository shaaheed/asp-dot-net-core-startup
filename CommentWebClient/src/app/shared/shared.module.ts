import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { BoxLoaderModule } from './box-loader.component';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { CheckPermissionDirective } from 'src/directives/permission.directive';
import { EnToBnDirective } from 'src/directives/en-to-bn.directive';
import { BanglaPipe } from 'src/pipes/bangla.pipe';
import { TimeAgoPipeModule } from 'src/pipes/time-ago.pipe';

@NgModule({
  declarations: [
    CheckPermissionDirective,
    EnToBnDirective,
    BanglaPipe
  ],
  imports: [
    TranslateModule,
    BoxLoaderModule,
    MomentPipeModule,
    TimeAgoPipeModule
  ],
  exports: [
    TranslateModule,
    BoxLoaderModule,
    MomentPipeModule,
    CheckPermissionDirective,
    EnToBnDirective,
    BanglaPipe
  ]
})
export class SharedModule {}