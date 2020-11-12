import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { TableComponent as T } from 'src/app/shared/table.component';
import { Observable } from 'rxjs';
import { ButtonConfig } from '../button.config';
import { TableConfig } from './table.config';
import { HttpService } from 'src/services/http/http.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TableComponent extends T {

  @Input() pageTitle: string;
  @Input() body: TemplateRef<any>;
  @Input() head: TemplateRef<any>;
  @Input() fetch: (pagination: string, search: string) => Observable<Object>;
  @Input() config: TableConfig;

  onLoadComplete = () => {
    this.changeDetector.detectChanges();
  }

  defaultRowButtons: ButtonConfig[] = [
    {
      label: 'edit',
      action: d => this.edit(d),
      // permissions: ['course.manage', 'course.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      // permissions: ['course.manage', 'course.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private router: Router,
    private changeDetector: ChangeDetectorRef,
    private httpService: HttpService
  ) {
    super(null);
  }

  ngOnInit() {
    if (!this.fetch && this.config?.fetchUrl) {
      this.fetch = (pagination, search) => this.httpService.get(this.buildUrl(this.config.fetchUrl, pagination, search))
    }
    if (!this.config.topRightButtons?.length) {
      this.config.topRightButtons = [
        {
          action: () => this.add(),
          label: 'new',
          icon: 'plus'
        },
        {
          action: () => this.refresh(),
          label: 'refresh',
          icon: 'sync'
        }
      ];
    }
    this.gets();
  }

  add() {
    if (this.config?.createPageRoute) {
      this.router.navigateByUrl(this.config?.createPageRoute);
    }
  }

  edit(model?) {
    if (model && this.config?.createPageRoute) {
      const route = this.config?.editPageRoute(model);
      this.router.navigateByUrl(route);
    }
  }

  gets() {
    if (this.fetch) {
      this.load(this.fetch);
    }
  }

  refresh() {
    this.gets();
  }

  private buildUrl(url: string, ...args) {
    const _args = args.filter(x => x);
    const _url = `${url}?${_args.join('&')}`;
    return _url;
  }

}
