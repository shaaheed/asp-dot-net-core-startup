import { ORGANIZATION_ROUTE } from '../../organizations/constants';
import { ROLE_ROUTE } from '../../roles/constants';
import { USER_ROUTE } from '../../users/constants';

export const getSettingRoutes = () => {
  const routes = [
    ORGANIZATION_ROUTE.PROFILE,
    ORGANIZATION_ROUTE.LIST,
    USER_ROUTE.LIST,
    ROLE_ROUTE.LIST
  ].map(x => {
    return { title: x.TITLE, icon: x.ICON, route: x.URL }
  });
  routes.push(...[{ title: 'preferences', icon: 'control', route: '' }])
  return routes;
}