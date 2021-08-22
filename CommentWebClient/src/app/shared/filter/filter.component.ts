import { trigger, transition, style, animate } from '@angular/animations'
import { ChangeDetectionStrategy, Component, Input, Output, ViewChild } from '@angular/core';
import { BaseComponent } from '../base.component';
import { NumberService } from 'src/services/number.service';
import { Filter, FilterConfig } from './filter.config';
import { eq, ne, gt, lt, ge, le, contains, startsWith, endsWith, between } from './operators';
import { NzPopoverComponent } from 'ng-zorro-antd/popover';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./filter.component.scss'],
  animations: [
    trigger(
      'animation', [
      transition(':enter', [
        style({ height: '0', opacity: 0 }),
        animate('1000ms', style({ height: '100%' }))
      ]),
      transition(':leave', [
        style({ height: '100%', opacity: 1 }),
        animate('1000ms', style({ height: '0' }))
      ])
    ]
    )
  ]
})
export class FilterComponent extends BaseComponent {

  @Output() onClear: () => void;
  @Output() onFilterCount: (count: number) => void;
  @Output() onApply: (filter: string) => void;
  @Input() config: FilterConfig;
  
  visible = false;
  @ViewChild('popover') popover: NzPopoverComponent;

  filterCount: number = 0;

  constructor(
    public numberService: NumberService
  ) {
    super();
  }

  ngOnInit() {
    if (!this.config) {
      this.config = {
        filters: <Filter[]>[
          {
            label: 'number',
            field: 'number',
            type: 'text'
          },
          {
            label: 'due',
            field: 'amountDue',
            type: 'number'
          },
          {
            label: 'total',
            field: 'totalAmount',
            type: 'number'
          },
          {
            label: 'date',
            field: 'issueDate',
            type: 'date'
          }
        ]
      };
    }

    if (this.config && this.config.filters) {
      this.config.filters.forEach(x => {
        if (x.active) {
          this.filterCount += 1;
        }
        x.operators = this.getOperators(x);
      })
      this.invoke(this.onFilterCount, this.filterCount);
    }
  }

  clear() {
    this.visible = false;
    this.popover._visible = false;
    this.invoke(this.onClear);
    this.invoke(this.config?.onClear);
  }

  apply() {
    this.visible = false;
    this.popover._visible = false;
    this.log('popover', this.popover);
    this.invoke(this.onApply, "");
    this.invoke(this.config?.onApply, "");
  }

  change(e) {
    this.log("change", e);
  }

  operatorChanged(e, filter: Filter) {
    this.log('operatorChanged', e);
    filter.value = '';
  }

  activeChanged(e) {
    this.log('activeChanged', e);
    if (e) {
      this.filterCount += 1;
    }
    else {
      const count = this.filterCount - 1;
      if (count < 0) {
        this.filterCount = 0;
      }
      else {
        this.filterCount = count;
      }
    }
    this.invoke(this.onFilterCount, this.filterCount);
    this.log('filter count', this.filterCount);
  }

  getOperators(filter: Filter): { value: string, label: string }[] {
    const _type = filter.type?.toLocaleLowerCase();
    let operators: { value: string, label: string }[] = [];
    if (_type == 'text') {
      operators = [eq, ne, contains, startsWith, endsWith];
    }
    else if (_type == 'number') {
      operators = [eq, ne, gt, lt, ge, le];
    }
    else if (_type == 'date') {
      operators = [eq, ne, gt, lt, ge, le, between];
    }
    if (!filter.operator && operators) {
      filter.operator = operators[0].value;
    }
    return operators;
  }

}
