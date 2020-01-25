import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-table-header',
  templateUrl: './table-header.component.html',
  styleUrls: ['./table-header.component.scss']
})
export class TableHeaderComponent {
  
  @Input() data: any = {};
  
  constructor() {
    
  }

}
