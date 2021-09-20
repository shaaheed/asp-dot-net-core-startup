import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { HttpService } from 'src/services/http/http.service';
import { SecurityService } from 'src/services/security.service';
import { AuthService } from 'src/services/auth.service';
import { IdentityService } from 'src/services/identity.service';
import {TranslateModule, TranslateLoader, TranslateService} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { BroadcastService } from 'src/services/broadcast.service';
import { ErrorInterceptor } from './error.interceptor';
import { environment } from 'src/environments/environment';
import { permissionFactory, PermissionService } from 'src/services/permission.service';
import { CacheService } from 'src/services/cache.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BaseHttpService } from 'src/services/http/base-http.service';
import { TimeAgoPipeModule } from 'src/pipes/time-ago.pipe';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { ValidatorService } from 'src/services/validator.service';
import { NumberService } from 'src/services/number.service';
import { LoginModule } from '../components/login/login.module';
import { AuthGuard } from '../guards/auth.guard';
import { OrganizationsResolver } from '../modules/organizations/organizations.resolver';
import { OrganizationService } from '../modules/organizations/organization.service';
import { IconModule } from './icon.module';
import { getLang } from 'src/services/utilities.service';
import { DrawerService } from 'src/services/drawer.service';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { SettingsService } from '../modules/settings/settings/settings.service';

registerLocaleData(en);

// AoT requires an exported function for factories
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, environment.langFilePath);
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    LoginModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    TimeAgoPipeModule,
    MomentPipeModule,
    IconModule,
    NzDrawerModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
    HttpService,
    BaseHttpService,
    SecurityService,
    PermissionService,
    OrganizationService,
    AuthGuard,
    NzMessageService,
    NzModalService,
    AuthService,
    IdentityService,
    BroadcastService,
    CacheService,
    ValidatorService,
    NumberService,
    DrawerService,
    SettingsService,
    { provide: ErrorHandler, useClass: ErrorHandler },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    {
      provide: APP_INITIALIZER,
      useFactory: permissionFactory,
      deps: [AuthService, SecurityService, PermissionService],
      multi: true
    },
    OrganizationsResolver
  ],
  bootstrap: [AppComponent, []]
})
export class AppModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}
