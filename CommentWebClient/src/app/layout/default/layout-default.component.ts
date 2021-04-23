import { Component, OnInit, VERSION } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NzDrawerService } from 'ng-zorro-antd/drawer';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { OrganizationService } from 'src/app/modules/organizations/organization.service';
import { SettingsComponent } from 'src/app/modules/settings/settings/settings.component';
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
  organizations: any[] = [];
  currentOrganization: any;

  constructor(
    private translation: TranslateService,
    private drawerService: NzDrawerService,
    private activatedRoute: ActivatedRoute,
    private organizationService: OrganizationService
  ) {
    super();
  }

  ngOnInit() {
    const data = this.activatedRoute.snapshot.data;
    if (data?.organizations?.data?.items) {
      this.organizations = data.organizations.data.items;
    }
    this.currentOrganization = this.organizationService.getCurrentOrganization();
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
        title: 'products',
        icon: 'gift',
        fn: () => true,
        nav: [
          {
            level: 2,
            title: 'products',
            route: '/products',
            fn: () => true,
          },
          {
            level: 2,
            title: 'product.categories',
            route: '/products/categories',
            fn: () => true,
          },
          {
            level: 2,
            title: 'inventory.adjustment',
            route: '/inventories/adjustments',
            fn: () => true,
          },
        ]
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
      },
      {
        level: 1,
        title: 'purchase',
        icon: 'shopping',
        fn: () => true,
        nav: [
          {
            level: 2,
            title: 'bills',
            route: '/bills',
            fn: () => true,
          },
          {
            level: 2,
            title: 'suppliers',
            route: '/suppliers',
            fn: () => true,
          }
        ]
      },
      {
        level: 1,
        title: 'settings',
        icon: 'setting',
        fn: () => true,
        nav: [
          {
            level: 2,
            title: 'units',
            route: '/units',
            fn: () => true,
          },
          {
            level: 2,
            title: 'unit.types',
            route: '/units/types',
            fn: () => true,
          },
          {
            level: 2,
            title: 'taxes',
            route: '/taxes',
            fn: () => true,
          }
        ]
      }
    ];

    this.checkNavGrant(nav);
    this.nav = nav;
    this.permissionLoaded = true;
  }

  selectOrganization(organization) {
    if (organization) {
      const isSameOrganization = this.currentOrganization.id == organization.id;
      if (!isSameOrganization) {
        this.currentOrganization = organization;
        this.organizationService.setCurrentOrganization(organization);
        window.location.reload();
      }
    }
  }

  newOrganization() {
    this._router.navigateByUrl('organizations/create');
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

  async openSettingsDrawer() {
    await this.openDrawer(SettingsComponent);
  }

  async openDrawer(component) {
    const ref = this.drawerService.create({
      nzContent: component,
      nzWrapClassName: 'app-right-drawer',
      // nzMask: false,
      nzWidth: 400,
      nzClosable: false,
      nzBodyStyle: { padding: 0 },
      nzMaskClosable: true,
      nzMaskStyle: { backgroundColor: 'transparent' }
    });
    this.log('settings drawer ref', ref);
  }

}

export interface ISidebarMenu {
  title: string;
  route?: string;
  icon?: string;
  childs?: ISidebarMenu[]
}
