import { makeRoute } from 'src/constants/route';

export const ROLE_ROUTE = {
    CREATE: makeRoute('/roles/create'),
    LIST: makeRoute('/roles', 'roles', 'safety')
}