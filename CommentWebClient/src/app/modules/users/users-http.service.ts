import { Injectable } from '@angular/core';
import { BaseHttpService } from 'src/services/http/base-http.service';

@Injectable()
export class UsersHttpService extends BaseHttpService {
    _url = "users";
}