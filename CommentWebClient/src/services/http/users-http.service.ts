import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class UsersHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public getUsers() {
        return this.httpService.get('users');
    }

    public addUser(body) {
        return this.httpService.post('users', body);
    }

    public deleteUser(id: number) {
        return this.httpService.delete(`users/${id}`);
    }

    public editUser(id: number, body) {
        return this.httpService.put(`users/${id}`, body);
    }

    public getUserGroups() {
        return this.httpService.get('users/groups');
    }

    public addUserGroup(body) {
        return this.httpService.post('users/groups', body);
    }

    public editUserGroup(id, body) {
        return this.httpService.put(`users/groups/${id}`, body);
    }

    public deleteUserGroup(id: number) {
        return this.httpService.delete(`users/groups/${id}`);
    }

}