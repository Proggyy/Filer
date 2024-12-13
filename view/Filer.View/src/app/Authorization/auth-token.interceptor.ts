import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { CookieService } from '../Services/cookie.service';
import { config } from '../../../config';

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
  let token = inject(CookieService).getCookie(config.TokenName);
  if(!token){ 
    return next(req);
  }
  req = req.clone({
    setHeaders:{
      Authorization: `Bearer ${token}`
    }
  })
  return next(req);
};
