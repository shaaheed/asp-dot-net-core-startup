import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, TemplateRef, Type, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ButtonConfig } from '../button.config';
import { TableConfig } from './table.config';
import { NzModalService } from 'ng-zorro-antd/modal';
import { getSearchableProperties } from 'src/decorators/searchable.decorator';
import { BaseComponent } from '../base.component';
import { message } from 'src/constants/message';
import { NumberService } from 'src/services/number.service';
import { NzTableComponent } from 'ng-zorro-antd/table';
import { getFilterString } from '../filter/filter.config';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TableComponent extends BaseComponent {

  @Input() pageTitle: string;
  @Input() body: TemplateRef<any>;
  @Input() head: TemplateRef<any>;
  @Input() fetch: (queryParams: string[]) => Observable<Object>;

  @Input() config: TableConfig;
  @Output() dataLoadCompleted = new EventEmitter();
  @Input() onDataLoadCompleted: () => void;
  @Input() headerStyle: any = {};
  @Input() boxStyle: any = {};
  @ViewChild('basicTable', { static: true }) table: NzTableComponent<any>;

  loading: boolean = true;
  total: number = 0;
  pageIndex: number = 1;
  pageSize: number = 500;
  items = [];
  additionalSearchTerm;

  onDeleted: (res: any) => void;
  onDeleteFailed: (res: any) => void;

  allChecked = false;
  setOfCheckedId = new Set<number>();
  indeterminate = false;
  listOfCurrentPageItems = [];
  rowItemDisabledFilterKey = "disabled";
  pageSizeOptions = [50, 100, 500];
  bottomTitle: string;

  private _fn: (queryParams: string[]) => Observable<Object>;
  private defaultHeaderStyle = {
    borderBottom: '1px solid #e4e4e4',
    padding: '16px'
  };
  private defaultBoxStyle = {
    margin: 0
  };

  private _fetchApiUrl: string = null;

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
    public numberService: NumberService,
    private changeDetectorRef: ChangeDetectorRef,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    if (snapshot?.data?.pageData) {
      this.config = snapshot.data.pageData
    }

    if (this.config) {

      this.headerStyle = this.config.headerStyle ?? this.headerStyle;
      this.boxStyle = this.config.boxStyle ?? this.boxStyle;

      const ctor = this.config.fetchApiUrl?.constructor?.name?.toLowerCase();
      if (ctor === "string") {
        this._fetchApiUrl = this.config.fetchApiUrl.toString();
      }
      else if (ctor === "function") {
        this._fetchApiUrl = (this.config.fetchApiUrl as ((data?: any) => string))((snapshot));
      }

      if (this.config.filterConfig) {
        this.config.filterConfig.onApply = filter => {
          if (filter) {
            this.load((queryParams: string[]) => this._httpService.get(this.buildUrl(this._fetchApiUrl, ...queryParams)));
          }
        }

        this.config.filterConfig.onClear = (filterCount?: number) => {
          if (filterCount) {
            this.load((queryParams: string[]) => this._httpService.get(this.buildUrl(this._fetchApiUrl, ...queryParams)));
          }
        }
      }

      if (!this.fetch && this.config.fetchApiUrl) {
        this.fetch = (queryParams: string[]) => {
          return this._httpService.get(this.buildUrl(this._fetchApiUrl, ...queryParams))
        }
      }

      if (!this.config.topRightButtons) {
        this.config.topRightButtons = [
          {
            action: () => this.add(),
            label: 'new',
            icon: 'plus',
            type: 'primary'
          },
          {
            action: () => this.refresh(),
            label: 'refresh',
            icon: 'sync'
          }
        ];
      }
    }

    this.headerStyle = Object.assign(this.defaultHeaderStyle, this.headerStyle);
    this.boxStyle = Object.assign(this.defaultBoxStyle, this.boxStyle);

    this.gets();
  }

  fill(response: any, items: any[] = null) {
    if (response && response.status == 200) {
      this.total = response.data.size;
      if (items == null) {
        if (!response.data.items && Array.isArray(response.data)) {
          this.items = response.data;
          this.total = response.data.length;
        }
        else {
          this.items = [];
          this.items = [...response.data.items];
          this.changeDetectorRef.detectChanges();
          if (this.table) {
            this.table.ngOnInit();
          }
        }
      }
    }
    this._loading(false);
  }

  async delete(e) {
    //const { ModalFooterComponent } = await import('./modal-footer.component');
    //this.vcr.clear();
    //const x = this.vcr.createComponent(this.cfr.resolveComponentFactory(ModalFooterComponent));
    //const y = template instanceof TemplateRef;
    const deleteModal = this._modalService.confirm({
      // nzViewContainerRef: this.vcr,
      nzTitle: this.instant(message.confirm),
      nzContent: /*ModalFooterComponent, //*/ this.instant(message.do_you_want_to_delete),
      nzOkText: this.instant(message.yes),
      nzCancelText: this.instant(message.no),
      nzOkLoading: false,
      nzClosable: false,
      // nzFooter: template,
      nzOnOk: () => {
        // deleteModal.getInstance().nzOkLoading = true;
        const url = this.config?.getDeleteApiUrl(e);
        this.subscribe(this._httpService.delete(url),
          res => {
            // deleteModal.getInstance().nzOkLoading = false;
            const text = this.instant(message.successfully_deleted);
            this.success(text);
            this.invoke(this.onDeleted, res);
            this.invoke(this.config?.onRowDeleted, res);
            //refresh data
            this.load(this._fn);
          },
          err => {
            // deleteModal.getInstance().nzOkLoading = false;
            this.invoke(this.onDeleteFailed, err);
            this.log('err', err)
          }
        );
      }
    });
  }

  getSearchTerms() {
    const searchableProperties: any = getSearchableProperties(this);
    if (searchableProperties) {
      return searchableProperties.join("&");
    }
    return "";
  }

  load(fn?: (queryParams: string[]) => Observable<Object>) {
    this._fn = fn;
    let offset = 0;
    if (this.pageIndex > 1) {
      offset = (this.pageSize * this.pageIndex) - this.pageSize;
    }
    const queryParams: string[] = [];
    queryParams.push(`offset=${offset}`);
    queryParams.push(`limit=${this.pageSize}`);

    const filter = getFilterString(this.config?.filterConfig);
    if (filter) {
      queryParams.push(`filter=${filter}`);
    }

    // let search = this.getSearchTerms();
    this._loading(true);
    let listFn;
    if (fn) {
      listFn = fn(queryParams);
    }
    if (listFn) {
      this.subscribe(listFn,
        (res: any) => {
          this.fill(res);
          this._loading(false);
          this.dataLoadCompleted.emit();
        },
        err => {
          this.log(err);
          this._loading(false);
          this.dataLoadCompleted.emit();
        }
      );
    }
  }

  pageIndexChanged(pageIndex) {
    this.pageIndex = pageIndex;
    this.load();
  }

  pageSizeChanged(pageSize) {
    this.pageSize = pageSize;
    this.load();
  }

  onAllChecked(checked: boolean): void {
    this.listOfCurrentPageItems.filter(x => !x[this.rowItemDisabledFilterKey]).forEach(({ id }) => this.updateCheckedSet(id, checked));
    this.refreshCheckedStatus();
  }

  onCurrentPageDataChange(listOfCurrentPageItems: []): void {
    this.listOfCurrentPageItems = listOfCurrentPageItems;
    this.refreshCheckedStatus();
  }

  refreshCheckedStatus(): void {
    const listOfEnabledData = this.listOfCurrentPageItems.filter(x => !x[this.rowItemDisabledFilterKey]);
    this.allChecked = listOfEnabledData.every(({ id }) => this.setOfCheckedId.has(id));
    this.indeterminate = listOfEnabledData.some(({ id }) => this.setOfCheckedId.has(id)) && !this.allChecked;
  }

  updateCheckedSet(id: number, checked: boolean): void {
    if (checked) {
      this.setOfCheckedId.add(id);
    } else {
      this.setOfCheckedId.delete(id);
    }
  }

  onItemChecked(id: number, checked: boolean): void {
    this.updateCheckedSet(id, checked);
    this.refreshCheckedStatus();
  }

  addModal<T>(component: Type<T>, modalService: NzModalService, params: any = {},) {
    const modal = modalService.create({
      nzWidth: '50%',
      nzContent: component,
      // nzGetContainer: () => document.body,
      nzComponentParams: params,
      nzFooter: null
    });
    const s = modal.afterOpen.subscribe(() => {
      const componentInstance = (<any>modal.getContentComponent());
      componentInstance.modalInstance = modal.componentInstance;
      componentInstance.id = params.id;
      componentInstance.onCheckMode = id => componentInstance.get(id);
      componentInstance.init();
    });
    const _fn = this._fn;
    const s2 = modal.afterClose.subscribe(x => {
      if (x === true) {
        this.load(_fn);
      }
    });
    // TODO: this._subscriptions.push(...[s, s2]);
  }

  add() {
    if (this.config?.createPageRoute) {
      const ctor = this.config.createPageRoute.constructor.name.toLowerCase();
      let route = "";
      if (ctor === "string") {
        route = this.config.createPageRoute.toString();
      }
      else if (ctor === "function") {
        route = (this.config.createPageRoute as (data?: any) => string)(this.activatedRoute.snapshot);
      }
      this.router.navigateByUrl(route);
    }
  }

  edit(model?) {
    if (model && this.config?.editPageRoute) {
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

  executeAction(button) {
    if (button.action) {
      button.action();
      if (this.config?.onClickButton) {
        this.config.onClickButton(button);
      }
    }
  }

  private buildUrl(url: string, ...args) {
    const _args = args.filter(x => x);
    const splitUrl = url.split('?');
    if (splitUrl.length >= 2) {
      url = splitUrl[0];
      const splitTerm = splitUrl[1].split('&');
      _args.push(...splitTerm);
    }
    const _url = `${url}?${_args.join('&')}`;
    return _url;
  }

  private _loading(value: boolean) {
    this.loading = value;
  }

}
