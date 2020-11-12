import { makeRoute } from 'src/constants/route';

export const ORGANIZATION_ROUTE = {
    CREATE: makeRoute('/organizations/create'),
    LIST: makeRoute('/organizations', 'organizations', 'bank'),
    PROFILE: makeRoute('/organizations/profile', 'organization.profile', 'profile')
}