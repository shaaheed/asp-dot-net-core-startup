import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NzDrawerRef } from 'ng-zorro-antd/drawer';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { ORGANIZATION_ROUTE } from '../../organizations/constants';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html'
})
export class SettingsComponent {

  config: PerfectScrollbarConfigInterface = {};
  items = []

  constructor(
    private router: Router,
    private drawerRef: NzDrawerRef
  ) {
  }

  ngOnInit() {
    const items = [
      ORGANIZATION_ROUTE.PROFILE,
      ORGANIZATION_ROUTE.LIST
    ].map(x => {
      return { title: x.TITLE, icon: x.ICON, route: x.URL }
    });
    items.push(...[{ title: 'users.and.roles', icon: 'team', route: 'users' },
    { title: 'preferences', icon: 'control', route: '' }])
    this.items = items;
  }

  close() {
    this.drawerRef.close();
  }

  goTo(obj) {
    if(obj && obj.route) {
      this.router.navigateByUrl(obj.route);
      this.close();
    }
  }

}
