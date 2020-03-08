import { Injectable } from '@angular/core';
import { HttpService } from 'src/services/http/http.service';

@Injectable()
export class InvoiceService {

    constructor(
        private httpService: HttpService
    ) { }

    public gets() {
        return this.httpService.get('invoices');
    }

    public get(id) {
        return this.httpService.get(`invoices/${id}`);
    }

    public add(body) {
        return this.httpService.post('invoices', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`invoices/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`invoices/${id}`, body);
    }

    public getPayments(invoiceId) {
        return this.httpService.get(`invoices/${invoiceId}/payments`);
    }

    public addPayment(invoiceId, body) {
        return this.httpService.post(`invoices/${invoiceId}/payments`, body);
    }

    public editPayment(invoiceId, body) {
        return this.httpService.put(`invoices/${invoiceId}/payments`, body);
    }

    public getCustomers() {
        return this.httpService.get(`customers`);
    }

    public getProducts() {
        return this.httpService.get(`products`);
    }

}