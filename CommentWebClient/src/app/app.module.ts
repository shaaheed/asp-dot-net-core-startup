import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IconsProviderModule } from './icons-provider.module';
import { NZ_ICONS } from 'ng-zorro-antd/icon';
import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { HttpService } from 'src/services/http/http.service';
import { SecurityService } from 'src/services/security.service';
import { AuthGuard } from './guards/auth.guard';
import { LoginModule } from './components/login/login.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { OAuthConfig, initOAuth } from 'src/configs/oauth.config';
import { AuthService } from 'src/services/auth.service';
import { IdentityService } from 'src/services/identity.service';
import {TranslateModule, TranslateLoader, TranslatePipe, TranslateService} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { BroadcastService } from 'src/services/broadcast.service';
import { ErrorInterceptor } from './error.interceptor';
import * as AllIcons from '@ant-design/icons-angular/icons'
import { IconDefinition } from '@ant-design/icons-angular';
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

registerLocaleData(en);

const antDesignIcons = AllIcons as {
  [key: string]: IconDefinition;
};
const icons: IconDefinition[] = Object.keys(antDesignIcons).map(key => antDesignIcons[key])

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
    IconsProviderModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    LoginModule,
    OAuthModule.forRoot(),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    TimeAgoPipeModule,
    MomentPipeModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
    { provide: NZ_ICONS, useValue: icons },
    HttpService,
    BaseHttpService,
    SecurityService,
    PermissionService,
    // TranslatePipe,
    AuthGuard,
    NzMessageService,
    NzModalService,
    // OAuthConfig,
    // {
    //   provide: APP_INITIALIZER,
    //   useFactory: initOAuth,
    //   deps: [OAuthConfig],
    //   multi: true
    // },
    AuthService,
    IdentityService,
    BroadcastService,
    CacheService,
    ValidatorService,
    NumberService,
    { provide: ErrorHandler, useClass: ErrorHandler },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    {
      provide: APP_INITIALIZER,
      useFactory: permissionFactory,
      deps: [AuthService, SecurityService, PermissionService],
      multi: true
    }
  ],
  bootstrap: [AppComponent, []]
})
export class AppModule {
  
}
