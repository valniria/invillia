import { Injectable } from '@angular/core';

import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
    HttpErrorResponse,
    HttpClient
}
    from '@angular/common/http';

import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppInitService } from '../../servicos/app-init.service';

// DOCS: https://angular.io/guide/http

@Injectable()
export class ValueHttpInterceptor implements HttpInterceptor {

    constructor(public router: Router,
        private http: HttpClient,
        private appInitService: AppInitService,
    ) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let _self: ValueHttpInterceptor = this;
        return next.handle(req).pipe(
            tap(event => {
                if (event instanceof HttpResponse) {
                }
            },
                error => {
                    console.log("Deu erro no http-interceptor!");
                })
        );
    }
}