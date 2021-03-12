import { Component } from '@angular/core';
import { BaseComponent } from '../base.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent extends BaseComponent {

  constructor() {
    super();
  }

  ngOnInit() {
  }
  
}
