import { makeRoute } from 'src/constants/route';
import { ORGANIZATION_ID } from './organization.service';

export const ORGANIZATION_ROUTE = {
    CREATE: makeRoute('/organizations/create'),
    LIST: makeRoute('/organizations', 'organizations', 'bank'),
    PROFILE: makeRoute(x => `/organizations/${ORGANIZATION_ID}/edit`, 'organization.profile', 'profile')
}