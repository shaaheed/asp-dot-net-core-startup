import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-invoice-home',
  templateUrl: './invoice-home.component.html'
})
export class InvoiceHomeComponent extends BaseComponent {

  loading: boolean = false;
  invoiceOption: string = 'invoices';

  private invoiceId: number

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.invoiceId = snapshot.params.id;
    this.optionChanged(this.invoiceOption);
  }

  optionChanged(option) {
    console.log(option)
    const extra = <NavigationExtras> {
      queryParams: {
        invoiceId: this.invoiceId
      },
      state: {
        invoiceId: this.invoiceId
      },
      data: {
        invoiceId: this.invoiceId
      }
    }
    switch (option) {
      case 'invoices':
        this.router.navigateByUrl(`/invoices/${this.invoiceId}/view`, extra);
        break;
      case 'payments':
        this.router.navigateByUrl(`/invoices/${this.invoiceId}/payments`, extra);
        break;
    }
  }

}
