import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CookieService {

  getCookie(cookieName: string){
    let match = document.cookie.match(
      new RegExp("(?:^|; )" + cookieName.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"));
    return match ? decodeURIComponent(match[1]) : undefined;
  }

  setCookie(cookieName: string, cookieValue: string, max_age: number, type:CookieType){
    let options:configObject;
    switch (type) {
      case CookieType.Basic:
        options = {
          'path': '/',
          'max-age': max_age.toString()
        };
        break;
      case CookieType.Auth:
        options = {
          'path': '/',
          'max-age': max_age.toString(),
          'samesite': 'strict',
          'secure': 'true',
          'httponly': 'true'
        };
        break;
    }
   
    let updatedCookie = encodeURIComponent(cookieName) + "=" + encodeURIComponent(cookieValue);

    for (let optionKey in options) {
      updatedCookie += "; " + optionKey;
      let optionValue = options[optionKey];
      updatedCookie += "=" + optionValue;
    } 
    document.cookie = updatedCookie;
  }

  clearCookie(cookieName: string){
    this.setCookie(cookieName, "", -1, CookieType.Basic)
  }
}

interface configObject{
  [key: string]: string | undefined;
}

export enum CookieType{
  Basic,
  Auth
}