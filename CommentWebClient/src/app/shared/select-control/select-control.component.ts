import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { NzSelectComponent } from 'ng-zorro-antd/select';
import { Observable } from 'rxjs';
import { invoke } from 'src/services/utilities.service';
import { AntControlComponent } from '../ant-control.component';
import { SelectConfig } from '../form-page/control.config';

@Component({
  selector: 'app-select-control',
  templateUrl: './select-control.component.html'
})
export class SelectControlComponent extends AntControlComponent {

  @Input() labelKey = 'name';
  @Input() idKey = 'id';
  @Input() info: (data?: any) => string | Promise<string>;
  @Input() mode: string = 'default';
  @Input() noLabel: boolean = false;
  @Input() onItemsLoaded: (items: []) => void;
  @Input() serverSearch: false;
  @Output() onOpen = new EventEmitter();
  @Output() onSelected = new EventEmitter();

  @ViewChild('select', { static: true }) select: NzSelectComponent;

  infoText: string = '';

  loading: boolean = false;
  searching: boolean = false;
  loadingMore: boolean = false;
  items = [];

  private total: number = 0;
  private offset: number = 0;
  private limit: number = 20;
  private fetchFn: (pagination: string, search?: string) => Observable<Object>;
  private subscriptions = [];
  private _selectFirstOption = false;
  private _onLoadCompleted: (items?: any[]) => void;

  private loadingMoreCallCount = 0;
  private lastLoadingMoreFetchItems = [];
  private openCount = 0;
  private fetchCalled = false;

  ngOnInit() {
    this.lastLoadingMoreFetchItems = [];
    this.loadingMoreCallCount = 0;
    if (this.config) {
      const config = <SelectConfig>this.config;
      this.info = config.info;
    }
    this.infoPromise();
    super.ngOnInit();
  }

  writeValue(val: any) {
    if (val) {
      if (Array.isArray(val)) {
        const items = val.map(x => {
          return {
            [this.idKey]: x[this.idKey],
            [this.labelKey]: x[this.labelKey] || x['name']
          };
        });
        this.items = items;
        this.value = this.items.map(x => x[this.idKey]);
      }
      else if (typeof (val) === "object") {
        const obj = {
          [this.idKey]: val[this.idKey],
          [this.labelKey]: val[this.labelKey] || val['name']
        };
        const items = [obj];
        this.items = items;
        this.value = obj[this.idKey];
      }
      else {
        this.value = val;
      }
    }
  }

  @Input() set registerFn(fn: (pagination: string, search?: string) => Observable<Object>) {
    if (fn) {
      this.register(fn);
    }
  }

  register(fn: (pagination: string, search?: string) => Observable<Object>) {
    this.fetchFn = fn;
    return this;
  }

  fetch(search?: string, clearOnFetch = false) {
    if (this.fetchFn) {
      this.fetchCalled = true;
      this.busy(true);
      if (this.searching) {
        this.offset = 0;
      }
      const pagination = `offset=${this.offset}&limit=${this.limit}`;
      const subscription = this.fetchFn(pagination, search).subscribe(
        (res: any) => {
          let items: any[] = res.data.items || [];
          this.lastLoadingMoreFetchItems = items;
          if (clearOnFetch || this.searching) {
            this.items = [];
          }
          invoke(this.onItemsLoaded, items);
          const filtered = items.filter(x => !this.items.find(y => y[this.idKey] == x[this.idKey]));
          const _items = [...this.items, ...filtered];
          setTimeout(() => this.items = _items, 0);
          this.busy(false);
          if (this._selectFirstOption && this.items.length > 0) {
            this.value = this.items[0][this.idKey];
            this.onSelected.emit(this.items[0]);
          }
          if (this._onLoadCompleted) {
            this._onLoadCompleted(_items);
          }
          this.searching = false;
          this.loading = false;
          this.loadingMore = false;
        },
        err => {
          this.busy(false);
        }
      );
      if (subscription) {
        this.subscriptions.push(subscription);
      }
    }
    return this;
  }

  fetchNext(search?: string) {
    this.offset = this.offset + this.limit;
    this.fetch(search);
    return this;
  }

  selectFirstOption() {
    this._selectFirstOption = true;
    return this;
  }

  setOpenState(state: boolean) {
    if (this.select) {
      this.select.setOpenState(state);
    }
  }

  loadMore() {
    const canLoadMore = (this.loadingMoreCallCount == 0
      || (this.loadingMoreCallCount > 0 && this.lastLoadingMoreFetchItems.length > 0))
      && !this.loadingMore;
    if (canLoadMore) {
      this.loadingMore = true;
      this.fetchNext()
      this.loadingMoreCallCount++;
    }
  }

  getLabel(data: any, key: string) {
    let d = JSON.parse(JSON.stringify(data));
    if (key) {
      key.split('.').forEach(k => {
        d = d[k];
      });
      return d;
    }
    return data.name;
  }

  addItem() {

  }

  onValueChange(e) {
    if (this.onChange) {
      this.onChange.emit(e);
    }
    const value = this.items.find(x => x[this.idKey] === e);
    if (value) {
      this.onSelected.emit(value);
    }
    // this.infoPromise(e);
  }

  onLoadCompleted(fn: (items?: any[]) => void) {
    this._onLoadCompleted = fn;
    return this;
  }

  onOpenChange(e) {
    if (this.onOpen) {
      this.onOpen.emit(e);
    }
    if (!this.fetchCalled && this.openCount <= 0) {
      this.fetch();
    }
    this.openCount++;
    console.log('openChange', this.openCount);
  }

  onSearch(e) {
    this.searching = true;
    this.fetch(e);
  }

  reset() {
    this.fetchCalled = false;
    this.openCount = 0;
    this.loadingMoreCallCount = 0;
    this.lastLoadingMoreFetchItems = [];
    this.items = [];
    this.ngControl.control.reset();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(item => {
      item.unsubscribe();
    });
  }

  private infoPromise(e?: any) {
    if (this.info /*&& this.items && this.items.length*/) {
      // const item = this.items.find(x => x.id == e);
      // if (item) {
      Promise.resolve(this.info()).then(x => {
        this.infoText = x || '';
      });
      // }
    }
  }

  private busy(value) {
    setTimeout(() => {
      this.loading = value
    }, 0);
  }

}