import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { AppInjector } from 'src/app/app.component';
import { NzMessageService } from 'ng-zorro-antd';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor() {

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    console.log('event ->>>', event)
                }
                return event
            }),
            catchError((err: HttpErrorResponse) => {
                console.log('error ->>>', err)
                const messageService = AppInjector.get(NzMessageService);
                const router = AppInjector.get(Router);
                return throwError(err);
            })
        );
    }

}