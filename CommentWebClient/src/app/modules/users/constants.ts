import { makeRoute } from 'src/constants/route';

export const USER_ROUTE = {
    CREATE: makeRoute('/users/create'),
    LIST: makeRoute('/users', 'users', 'team')
}