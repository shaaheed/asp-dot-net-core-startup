import { Injectable } from '@angular/core';
import { HttpService } from 'src/services/http/http.service';

@Injectable()
export class PaymentService {

    constructor(
        private httpService: HttpService
    ) { }

    public getPaymentMethods() {
        return this.httpService.get('payments/payment-methods');
    }

}