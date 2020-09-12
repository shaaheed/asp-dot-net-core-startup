import { Injectable } from '@angular/core';
import { HttpService } from 'src/services/http/http.service';

@Injectable()
export class VendorService {

    constructor(
        private httpService: HttpService
    ) { }

    public gets() {
        return this.httpService.get('vendors');
    }

    public get(id) {
        return this.httpService.get(`vendors/${id}`);
    }

    public add(body) {
        return this.httpService.post('vendors', body);
    }

    public update(id, body) {
        return this.httpService.put(`vendors/${id}`, body);
    }

    public delete(id: number) {
        return this.httpService.delete(`vendors/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`vendors/${id}`, body);
    }

}