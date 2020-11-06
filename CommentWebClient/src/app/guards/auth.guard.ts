import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivate, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs';
import { cache } from 'src/constants/cache';
import { AuthService } from 'src/services/auth.service';
import { PermissionService } from 'src/services/permission.service';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

    constructor(
        private router: Router,
        private authService: AuthService,
        private permissionService: PermissionService
    ) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.check(route);
    }

    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return this.check(childRoute);
    }

    private check(route: ActivatedRouteSnapshot): boolean | Observable<boolean> {
        const authenticated = this.authService.isAuthenticated();
        if (!authenticated) {
            this.router.navigateByUrl('/');
            return false;
        }
        let _route = route;
        while (_route.firstChild) {
            _route = _route.firstChild;
        }
        const permissions = _route.data?.permissions;
        if (route.component && permissions && permissions.length > 0) {
            let granted = false;
            const cacheKey = permissions.toString();
            if (cache.permission.hasOwnProperty(cacheKey)) {
                granted = cache.permission[cacheKey];
            }
            else {
                const permittedPermissions = this.permissionService.getPermissions();
                granted = this.permissionService.includes(permittedPermissions, permissions);
                cache.permission[cacheKey] = granted;
            }
            if (!granted) {
                // return true;
                this.router.navigateByUrl('/access-denied');
            }
            return granted;
        }
        else {
            return authenticated;
        }
    }

}