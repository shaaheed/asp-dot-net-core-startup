import { Injectable } from '@angular/core';

export let CURRENCY = ''
export let ORGANIZATION_ID = ''
export const ORGANIZATION_KEY = 'current_organization';

@Injectable()
export class OrganizationService {

  getCurrentOrganization(): any {
    const currentOrganization = localStorage.getItem(ORGANIZATION_KEY);
    if (currentOrganization) {
      return JSON.parse(currentOrganization);
    }
  }

  setCurrentOrganization(organization: any): void {
    if (organization) {
      localStorage.removeItem(ORGANIZATION_KEY);
      CURRENCY = organization.currency || '';
      ORGANIZATION_ID = organization.id || '';
      const organizationString = JSON.stringify(organization);
      localStorage.setItem(ORGANIZATION_KEY, organizationString);
    }
  }

  getCurrency(): string {
    const o = this.getCurrentOrganization();
    if (o) {
      return o.currency || '';
    }
    return '';
  }

}