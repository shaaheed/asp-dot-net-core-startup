import { Component, OnInit, VERSION } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { OrganizationService } from 'src/app/modules/organizations/organization.service';
import { SettingsService } from 'src/app/modules/settings/settings/settings.service';
import { BaseComponent } from 'src/app/shared/base.component';
import { DrawerService } from 'src/services/drawer.service';
import { getLang } from 'src/services/utilities.service';

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

  settingsSelected: boolean = false;
  sideMenuPerfectScrollbarHeight = 'calc(100vh - 100px)';

  constructor(
    private translation: TranslateService,
    private drawerService: DrawerService,
    private activatedRoute: ActivatedRoute,
    private organizationService: OrganizationService,
    private settingsService: SettingsService
  ) {
    super();
  }

  ngOnInit() {
    const data = this.activatedRoute.snapshot.data;
    if (data?.organizations?.data?.items) {
      this.organizations = data.organizations.data.items;
    }
    this.currentOrganization = this.organizationService.getCurrentOrganization();
    this.version = `Angular v${VERSION.full}`;
    this.selectedLanguage = getLang();

    const menus = this.getPrimarySideMenus();
    this.checkNavGrant(menus);
    this.nav = menus;
    this.permissionLoaded = true;

    this.subscribe(
      this.settingsService.onSelect,
      (menu: any) => {
        if (!this.settingsSelected) {
          this.sideMenuPerfectScrollbarHeight = 'calc(100vh - 141px)';
          this.settingsSelected = true;
          this.nav = this.settingsService.getMenus();
        }
      }
    );
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

  navCreateRouteClicked(n) {
    if (n.createRoute) {
      this.goTo(n.createRoute);
    }
  }

  navigate(b) {
    if (!b.last) {
      this.goTo(b.route);
    }
  }

  languageChanged(language) {
    this.translation.use(language);
    localStorage.setItem('app_lang', language);
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
    const module = import('../../modules/settings/settings/settings.module');
    const component = import('../../modules/settings/settings/settings.component');
    await this.drawerService.open(module, component);
  }

  closeSettingsMenu() {
    this.sideMenuPerfectScrollbarHeight = 'calc(100vh - 100px)';
    this.settingsSelected = false;
    this.settingsService.deselect();
    const menus = this.getPrimarySideMenus();
    this.checkNavGrant(menus);
    this.nav = menus;
  }

  private getPrimarySideMenus() {
    return [
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
            createRoute: '/products/create'
          },
          {
            level: 2,
            title: 'product.categories',
            route: '/products/categories',
            createRoute: '/products/categories/create',
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
            createRoute: '/invoices/create',
            fn: () => true,
          },
          {
            level: 2,
            title: 'customers',
            route: '/customers',
            createRoute: '/customers/create',
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
            createRoute: '/bills/create',
            fn: () => true,
          },
          {
            level: 2,
            title: 'suppliers',
            route: '/suppliers',
            createRoute: '/suppliers/create',
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
            createRoute: '/units/create',
            fn: () => true,
          },
          {
            level: 2,
            title: 'unit.types',
            route: '/units/types',
            createRoute: '/units/types/create',
            fn: () => true,
          },
          {
            level: 2,
            title: 'taxes',
            route: '/taxes',
            createRoute: '/taxes/create',
            fn: () => true,
          }
        ]
      }
    ];
  }

}

export interface ISidebarMenu {
  title: string;
  route?: string;
  icon?: string;
  children?: ISidebarMenu[]
}
