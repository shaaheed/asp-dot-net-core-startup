import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ListPageConfig } from './list.config';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListComponent {

  @Input() config: ListPageConfig;
  onDataLoadCompleted = () => {
    console.log('onDataLoadCompleted');
  }

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    if (snapshot?.data?.pageData) {
      this.config = snapshot.data.pageData
    }
  }

  onTableDataLoadCompleted() {
    console.log('dddddddddd load completed');
  }

}
