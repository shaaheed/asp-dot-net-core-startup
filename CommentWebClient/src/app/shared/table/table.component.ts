import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ContentChildren, Input, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { TableComponent as T } from 'src/app/shared/table.component';
import { IButton } from 'src/app/shared/table-actions.component';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TableComponent extends T {

  @Input() body: TemplateRef<any>;
  @Input() head: TemplateRef<any>;
  @Input() fetch: (pagination: string, search: string) => Observable<Object>;
  
  // @ContentChildren(TableRowComponent) inputRows: QueryList<TableRowComponent>;
  // public rows: TableRowComponent[];

  onLoadComplete = () => {
    console.log('loaded');
    this.c.detectChanges();
  }

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
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
    private c: ChangeDetectorRef
  ) {
    super(null);
  }

  ngOnInit() {
    this.gets();
  }

  // public ngAfterContentInit(): void {
  //   this.inputRows.forEach(row => {
  //     // console.log(row);
  //   });
  //   this.rows = this.inputRows.toArray();
  // }

  add(model = null) {
    if (model) {
      this.router.navigateByUrl(`/organizations/${model.id}/edit`);
    }
    else {
      this.router.navigateByUrl('/organizations/create');
    }
  }

  gets() {
    // this.load();
    if(this.fetch) {
      this.load(this.fetch);
    }
  }

  refresh() {
    this.gets();
  }

}
