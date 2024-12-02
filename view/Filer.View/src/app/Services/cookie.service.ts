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

  setCookie(cookieName: string, cookieValue: string, max_age: number){
    let options:configObject = {
      'path': '/',
      'max-age': max_age.toString()
   };
  
    let updatedCookie = encodeURIComponent(cookieName) + "=" + encodeURIComponent(cookieValue);

    for (let optionKey in options) {
      updatedCookie += "; " + optionKey;
      let optionValue = options[optionKey];
      updatedCookie += "=" + optionValue;
    }
  
    document.cookie = updatedCookie;
    console.log(updatedCookie);
  }
}

interface configObject{
  [key: string]: string | undefined;
}