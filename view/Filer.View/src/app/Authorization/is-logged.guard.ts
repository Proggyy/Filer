import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';
import { CookieService } from '../Services/cookie.service';
import { config } from '../../../config';

export const isLoggedGuard: CanActivateFn = (route, state) => {
  if(inject(CookieService).getCookie(config.TokenName)){ 
    return true;
  }
  return inject(Router).createUrlTree(["/login"]);
};
