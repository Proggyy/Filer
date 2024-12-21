import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import {config} from '../../../config';
import { CookieService, CookieType } from './cookie.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient, private cookie: CookieService, private router: Router){}

  Login(login: string, password: string){
    this.http.post<TokenResponse>(config.ApiUri + "api/auth/login",
      {"Login": login, "Password": password})
    .pipe().subscribe({next: (data:any) => {
      if(data.AccessToken != ""){
        let formatData:TokenResponse = {AccessToken: data.accessToken, RefreshToken: data.refreshToken}
        this.SaveToken(formatData);
        this.router.navigate(["/main"]);
    }
  }});
  }

  Register(login: string, userName: string,password: string) : Observable<any>{
    var istrue = this.http.post(config.ApiUri + "api/auth/register",
      {"Login": login, "UserName": userName,"Password": password});
    return istrue;
  }

  RefreshToken(token: TokenResponse): Observable<TokenResponse>{
    return this.http.post<TokenResponse>(config.ApiUri + "api/auth/refresh", {
      AccessToken: token.AccessToken, 
      RefreshToken: token.RefreshToken
    }).pipe(
      tap(val => this.SaveToken(val)),
      catchError(err => {
        this.Logout();
        return throwError(() => err);
      })
    );
  }

  GetAuthCookie():TokenResponse{
    let token = this.cookie.getCookie(config.TokenName) ?? "";
    let refresh = this.cookie.getCookie(config.RefreshName) ?? "";
    return {AccessToken: token, RefreshToken: refresh};
  }

  Logout(){
    this.cookie.clearCookie(config.TokenName);
    this.cookie.clearCookie(config.RefreshName);
    this.router.navigate(["login"]);
  }
  
  SaveToken(data:TokenResponse){
    let expires = config.ExpiresHours * 60 * 60;
    this.cookie.setCookie(config.TokenName,data.AccessToken, expires, CookieType.Auth);
    this.cookie.setCookie(config.RefreshName,data.RefreshToken, expires, CookieType.Auth);
  }
}

export interface TokenResponse{
  AccessToken: string, 
  RefreshToken: string
}
