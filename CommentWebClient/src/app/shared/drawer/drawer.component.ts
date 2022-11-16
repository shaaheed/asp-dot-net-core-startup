import { Component, Input, TemplateRef } from '@angular/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { DrawerService } from 'src/services/drawer.service';

@Component({
  selector: 'app-drawer',
  templateUrl: './drawer.component.html',
  styleUrls: ['./drawer.component.scss']
})
export class DrawerComponent {

  loading: boolean = false;
  noData: boolean = false;
  @Input() title: string = '';
  @Input() header: TemplateRef<any>;
  @Input() body: TemplateRef<any>;

  config: PerfectScrollbarConfigInterface = {};

  constructor(
    private drawerService: DrawerService
  ) {

  }

  ngOnInit(): void {
    //
  }

  ngAfterViewInit() {

  }

  close() {
    this.drawerService.close();
  }

}
