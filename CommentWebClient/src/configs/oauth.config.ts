import { Injectable } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';

export const oAuthDevelopmentConfig: AuthConfig = {
    clientId: 'root_client',
    scope: 'offline_access webapi openid',
    oidc: false,
    issuer: 'https://localhost:44388',
    requireHttps: true
};

/**
 * angular-oauth2-oidc configuration.
 */
@Injectable()
export class OAuthConfig {

    constructor(private oAuthService: OAuthService) { }

    load(): Promise<object> {
        this.oAuthService.configure(oAuthDevelopmentConfig);
        const url = 'https://localhost:44388/.well-known/openid-configuration';

        // Defines the storage.
        this.oAuthService.setStorage(localStorage);
        // Loads Discovery Document.
        return this.oAuthService.loadDiscoveryDocument(url);
    }

}

export function initOAuth(oAuthConfig: OAuthConfig): Function {
    return () => oAuthConfig.load();
}


