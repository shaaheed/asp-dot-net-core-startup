import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';

@Injectable()
export class OrganizationService {

    constructor(
        private httpService: HttpService
    ) { }

    public list() {
        return this.httpService.get('organizations');
    }

    public get(id) {
        return this.httpService.get(`organizations/${id}`);
    }

    public add(body) {
        return this.httpService.post('organizations', body);
    }

    public update(id, body) {
        return this.httpService.put(`organizations/${id}`, body);
    }

    public delete(id: number) {
        return this.httpService.delete(`organizations/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`organizations/${id}`, body);
    }

}