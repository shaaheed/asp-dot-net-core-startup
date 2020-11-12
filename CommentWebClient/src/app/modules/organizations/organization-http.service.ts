import { Injectable } from '@angular/core';
import { BaseHttpService } from 'src/services/http/base-http.service';

@Injectable()
export class OrganizationHttpService extends BaseHttpService {
    _url = `organizations`;
}