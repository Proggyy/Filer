import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { AuthService } from '../../Services/auth.service';
import { CookieService } from '../../Services/cookie.service';
import { RegistrationComponent } from './registration/registration.component';



@NgModule({
  declarations: [LoginComponent, RegistrationComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AuthService, CookieService],
  bootstrap: [LoginComponent, RegistrationComponent]
})
export class AuthentificationModule { }
