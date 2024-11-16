import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {config} from '../../../config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient){}

  Login(login: string, password: string) : Observable<any>{
    var token = this.http.post(config.ApiUri + "api/auth/login",{"Login": login, "Password": password});
    return token;
  }
  Register(login: string, userName: string,password: string) : Observable<any>{
    var istrue = this.http.post(config.ApiUri + "api/auth/register",{"Login": login, "UserName": userName,"Password": password});
    return istrue;
  }
}
