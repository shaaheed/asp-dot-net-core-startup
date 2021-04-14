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
      const type = typeof (obj.route);
      if (type == "string") {
        this.router.navigateByUrl(obj.route);
      }
      else if (type == "function") {
        const url = obj.route();
        if (url) {
          this.router.navigateByUrl(url);
        }
        else {
          console.log('invalid url');
        }
      }
      this.close();
    }
  }

}
