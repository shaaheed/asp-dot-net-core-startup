import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CURRENCY } from 'src/app/modules/organizations/organization.service';
import { BaseComponent } from 'src/app/shared/base.component';
import { DrawerService } from 'src/services/drawer.service';

@Component({
  selector: 'app-contact-drawer',
  templateUrl: './contact-drawer.component.html',
  styleUrls: ['./contact-drawer.component.scss'],
  // changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactDrawerComponent extends BaseComponent {

  loading: boolean = false;
  noData: boolean = false;
  currency;
  contact: any = null;

  constructor(
    private drawerService: DrawerService
  ) {
    super();
  }

  ngOnInit(): void {
    this.currency = CURRENCY;
    const contactId = this.drawerService.getExtra()?.id;
    if (contactId) {
      const contact = this._httpService.get(`contacts/${contactId}`);
      this.subscribe(contact,
        (res: any) => {
          this.contact = res.data;
        },
        err => { }
      );
    }
  }

  ngAfterViewInit() {

  }

}
