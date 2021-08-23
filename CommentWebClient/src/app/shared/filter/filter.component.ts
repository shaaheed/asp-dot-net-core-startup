import { trigger, transition, style, animate } from '@angular/animations'
import { ChangeDetectionStrategy, Component, Input, Output } from '@angular/core';
import { BaseComponent } from '../base.component';
import { NumberService } from 'src/services/number.service';
import { IFilter, FilterConfig, getFilterString } from './filter.config';
import { getOperators } from './operators';

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
  filterCount: number = 0;

  constructor(
    public numberService: NumberService
  ) {
    super();
  }

  ngOnInit() {
    if (!this.config) {
      this.config = {
        filters: <IFilter[]>[
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
        x.operators = getOperators(x);
      })
      this.invoke(this.onFilterCount, this.filterCount);
    }
  }

  clear() {
    this.visible = false;
    if (this.config?.filters) {
      this.filterCount = 0;
      this.config.filters.forEach(x => {
        x.active = false;
        x.value = '';
      });
    }
    this.invoke(this.onClear);
    this.invoke(this.config?.onClear);
  }

  apply() {
    this.visible = false;
    const filter = getFilterString(this.config);
    this.invoke(this.onApply, filter);
    this.invoke(this.config?.onApply, filter);
  }

  change(e) {
    this.log("change", e);
  }

  operatorChanged(e, filter: IFilter) {
    filter.value = '';
  }

  activeChanged(e) {
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
  }

  onChangeDate(e) {
    this.log('onChangeDate', e);
  }
}
