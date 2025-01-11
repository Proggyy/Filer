import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { AuthentificationModule } from './Modules/authentification/authentification.module';
import { authTokenInterceptor } from './Authorization/auth-token.interceptor';
import { MainComponent } from './Components/main/main.component';
import { MainModule } from './Modules/main/main.module';


@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    AppRoutingModule,
    AuthentificationModule,
    MainModule
  ],
  providers: [provideHttpClient(withInterceptors([authTokenInterceptor]))],
  bootstrap: [AppComponent]
})
export class AppModule { }
