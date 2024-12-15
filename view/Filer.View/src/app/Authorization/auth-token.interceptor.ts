import { HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { catchError, switchMap, throwError } from 'rxjs';

let isRefresh:boolean = false;

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const token = authService.GetAuthCookie().AccessToken;
  if(!token){ 
    return next(req);
  }

  if(isRefresh){
    return refreshToken(authService, req, next);
  }
  
  return next(addTokenToResponse(req, token)).pipe(
    catchError(err => {
      if(err.status === 401){ 
        return refreshToken(authService, req, next);
      }
      return throwError(() => err);
    })
  )
};

const refreshToken = (authService: AuthService, req: HttpRequest<any>, next: HttpHandlerFn) => {
  let tokens = authService.GetAuthCookie();
  if(!isRefresh){  
    isRefresh = true;
    return authService.RefreshToken(tokens)
    .pipe(
      switchMap(res => {
        isRefresh = false;
        return next(addTokenToResponse(req, res.AccessToken));
      })
    )
  }
  return next(addTokenToResponse(req, tokens.AccessToken));
}

const addTokenToResponse = (req: HttpRequest<any>, token: string) => 
  req.clone({setHeaders: {
    Authorization: "Bearer "+token
  }})

