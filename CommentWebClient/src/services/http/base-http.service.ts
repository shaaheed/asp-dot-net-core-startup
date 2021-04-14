import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppInjector } from 'src/app/app/app.component';
import { HttpService } from './http.service';

@Injectable()
export class BaseHttpService {

    protected _url;
    protected _httpService;

    constructor() {
        this._httpService = AppInjector.get(HttpService);
    }

    public init(baseUrl: string) {
        this._url = baseUrl;
    }

    public list(pagination?, search?): Observable<Object> {
        return this._httpService.get(this.buildUrl(this._url, pagination, search));
    }

    public get(id) {
        return this._httpService.get(`${this._url}/${id}`);
    }

    public add(body) {
        return this._httpService.post(this._url, body);
    }

    public update(id, body) {
        return this._httpService.put(`${this._url}/${id}`, body);
    }

    public delete(id: number) {
        return this._httpService.delete(`${this._url}/${id}`);
    }

    public edit(id: number, body) {
        return this._httpService.put(`${this._url}/${id}`, body);
    }

    protected buildUrl(url: string, ...args) {
        const _args = args.filter(x => x);
        const _url = `${url}?${_args.join('&')}`;
        return _url;
    }

}