import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/services/http/http.service';
import { map } from 'rxjs/operators';
import { OrganizationService } from './organization.service';

@Injectable()
export class OrganizationsResolver implements Resolve<any> {

    constructor(
        private httpService: HttpService,
        private organizationService: OrganizationService
    ) {
    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.httpService.get('organizations').pipe(
            map((x: any) => {
                if (x.data.items) {
                    const org = x.data.items[0];
                    const currentOrganization = this.organizationService.getCurrentOrganization();
                    if (!currentOrganization && org) {
                        this.organizationService.setCurrentOrganization(org);
                    }
                    else {
                        const found = x.data.items.find(x => x.id == currentOrganization.id);
                        if (found) {
                            this.organizationService.setCurrentOrganization(found);
                        }
                    }
                }
                return x;
            })
        )
    }
}