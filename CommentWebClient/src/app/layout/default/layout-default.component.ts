import { Component, OnInit, VERSION } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-layout-default',
  templateUrl: './layout-default.component.html',
  styleUrls: ['./layout-default.component.scss']
})
export class LayoutDefaultComponent extends BaseComponent implements OnInit {

  count = 2;
  selectedLanguage = ''
  nav = [];
  version;
  config: PerfectScrollbarConfigInterface = {};
  permissionLoaded = false;
  visible = false;

  constructor(
    private translation: TranslateService
  ) {
    super();
  }

  ngOnInit() {
    this.version = `Angular v${VERSION.full}`
    this.selectedLanguage = localStorage.getItem('lang') || 'bn'
    const nav = [
      {
        level: 1,
        title: 'home',
        route: '/',
        icon: 'home',
        fn: () => true
      },
      {
        level: 1,
        title: 'organization',
        route: '/organizations',
        icon: 'appstore',
        fn: () => true,
      },
      {
        level: 1,
        title: 'products',
        route: '/products',
        icon: 'gift',
        fn: () => true,
      },
      {
        level: 1,
        title: 'sales',
        icon: 'shopping',
        fn: () => true,
        nav: [
          {
            level: 2,
            title: 'invoices',
            route: '/invoices',
            fn: () => true,
          },
          {
            level: 2,
            title: 'customers',
            route: '/customers',
            fn: () => true,
          }
        ]
      }
    ];

    this.checkNavGrant(nav);
    this.nav = nav;
    this.permissionLoaded = true;
  }

  navClicked(n) {
    if (n.route) {
      this.goTo(n.route);
    }
  }

  navigate(b) {
    if (!b.last) {
      this.goTo(b.route);
    }
  }

  languageChanged(language) {
    this.translation.use(language);
    localStorage.setItem('lang', language);
    this.log('language', language);
  }

  checkNavGrant(nav: any[]) {
    nav.forEach(n => {
      if (n.fn) {
        n.granted = n.fn(); //n.fn(this.permissionService.getPermissions());
      }
      else {
        n.granted = false;
      }
      if (n.nav) {
        this.checkNavGrant(n.nav)
      }
    });
  }

  close(): void {
    this.visible = false;
  }

}

export interface ISidebarMenu {
  title: string;
  route?: string;
  icon?: string;
  childs?: ISidebarMenu[]
}
