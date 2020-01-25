import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-layout-default',
  templateUrl: './layout-default.component.html',
  styleUrls: ['./layout-default.component.scss']
})
export class LayoutDefaultComponent implements OnInit {

  count = 2;
  selectedLanguage = ''
  navs: ISidebarMenu[] = [];

  constructor(
    private translation: TranslateService
  ) { }

  ngOnInit() {
    this.selectedLanguage = localStorage.getItem('lang') || 'bn'
    this.navs = <ISidebarMenu[]>[
      {
        title: 'sales',
        childs: <ISidebarMenu[]> [
          {
            title: 'products',
            route: '/products'
          }
        ]
      }
    ]
  }

  languageChanged(language) {
    this.translation.use(language);
    localStorage.setItem('lang', language);
    console.log('language', language);
  }

}

export interface ISidebarMenu {
  title: string;
  route?: string;
  icon?: string;
  childs?: ISidebarMenu[]
}
