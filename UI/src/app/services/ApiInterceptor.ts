import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import { AppConfig } from '../app.config';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var apiBaseUrl = AppConfig.ApiBaseUrl;
    const apiReq = req.clone(
      {
        url: `${apiBaseUrl}/${req.url}`,
        setHeaders: {
          'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': '*',
          // 'api-version':'1.0',
        }
      });
    return next.handle(apiReq);
  }
}
