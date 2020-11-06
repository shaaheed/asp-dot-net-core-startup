import { Directive, TemplateRef, ViewContainerRef, Input } from '@angular/core';
import { cache } from 'src/constants/cache';
import { PermissionService } from 'src/services/permission.service';

@Directive({
    selector: '[checkPermission]'
})
export class CheckPermissionDirective {

    private hasView = false;

    @Input() set checkPermission(permissions: string | string[]) {
        let condition = false;
        if(permissions) {
            const cacheKey = permissions.toString();
            if (cache.permission.hasOwnProperty(cacheKey)) {
                condition = cache.permission[cacheKey];
            }
            else {
                const _permissions = this.permissionService.getPermissions();
                if (Array.isArray(permissions)) {
                    condition = permissions.some(x => _permissions.includes(x));
                }
                else {
                    condition = _permissions.includes(permissions);
                }
                cache.permission[cacheKey] = condition;
            }
        }
        else {
            condition = true;
        }
        if (condition && !this.hasView) {
            this.viewContainer.createEmbeddedView(this.templateRef);
            this.hasView = true;
        } else if (condition && this.hasView) {
            this.viewContainer.clear();
            this.hasView = false;
        }
    }

    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private permissionService: PermissionService
    ) { }
}
