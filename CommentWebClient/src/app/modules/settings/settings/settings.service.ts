import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { makeRoute } from 'src/constants/route';
import { DrawerService } from 'src/services/drawer.service';
import { ORGANIZATION_ROUTE } from '../../organizations/constants';
import { ORGANIZATION_ID } from '../../organizations/organization.service';
import { ROLE_ROUTE } from '../../roles/constants';
import { USER_ROUTE } from '../../users/constants';

@Injectable()
export class SettingsService {

  private _selected: any = null;

  onSelect: Subject<any> = new Subject<any>();
  onDeselect: Subject<any> = new Subject<any>();

  constructor(
    private router: Router,
    private drawerService: DrawerService
  ) { }

  select(nav: any): void {
    this.navigate(nav);
    this._selected = nav;
    this.onSelect.next(this._selected);
  }

  deselect(): void {
    this._selected = null;
    this.onDeselect.next(null);
  }

  getMenus = () => {
    const routes = [
      ORGANIZATION_ROUTE.PROFILE,
      ORGANIZATION_ROUTE.LIST,
      USER_ROUTE.LIST,
      ROLE_ROUTE.LIST,
      makeRoute(`/organizations/${ORGANIZATION_ID}/currencies`, 'currencies', 'safety'),
      makeRoute('/variants', 'variants', 'safety'),
      makeRoute('/priceLevels', 'price.levels', 'safety'),
      makeRoute('/units/types', 'units', 'safety'),
      makeRoute('/terms', 'terms', 'safety'),
    ].map(x => {
      return { title: x.TITLE, icon: x.ICON, route: x.URL }
    });
    routes.push(...[{ title: 'preferences', icon: 'control', route: '' }]);
    routes.forEach((x: any) => x.granted = true);
    return routes;
  }

  private navigate(nav) {
    if (nav && nav.route) {
      const type = typeof (nav.route);
      if (type == "string") {
        this.router.navigateByUrl(nav.route);
      }
      else if (type == "function") {
        const url = nav.route();
        if (url) {
          this.router.navigateByUrl(url);
        }
        else {
          console.log('invalid url');
        }
      }
      this.drawerService.close();
    }
  }

}