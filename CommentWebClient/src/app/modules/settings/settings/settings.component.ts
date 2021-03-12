import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NzDrawerRef } from 'ng-zorro-antd/drawer';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { getSettingRoutes } from './settings.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html'
})
export class SettingsComponent {

  config: PerfectScrollbarConfigInterface = {};
  items = [];

  constructor(
    private router: Router,
    private drawerRef: NzDrawerRef
  ) {
  }

  ngOnInit() {
    this.items = getSettingRoutes();
  }

  close() {
    this.drawerRef.close();
  }

  goTo(obj) {
    if (obj && obj.route) {
      this.router.navigateByUrl(obj.route);
      this.close();
    }
  }

}
