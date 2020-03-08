import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-invoice-home',
  templateUrl: './invoice-home.component.html',
  styleUrls: ['./invoice-home.component.scss']
})
export class InvoiceHomeComponent extends BaseComponent {

  loading: boolean = false;
  invoiceOption: string = 'invoice';

  private invoiceId: number

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    debugger
    const snapshot = this.activatedRoute.snapshot;
    this.invoiceId = Number(snapshot.params.id);
  }

  optionChanged(option) {
    console.log(option)
    switch (option) {
      case 'invoices':
        this.router.navigateByUrl(`/invoices/${this.invoiceId}/view`);
        break;
      case 'payments':
        this.router.navigateByUrl(`/invoices/${this.invoiceId}/payments`);
        break;
    }
  }

}
