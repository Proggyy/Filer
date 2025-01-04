import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Modules/authentification/login/login.component';
import { isLoggedGuard } from './Authorization/is-logged.guard';
import { MainComponent } from './Components/main/main.component';
import { RegistrationComponent } from './Modules/authentification/registration/registration.component';

const routes: Routes = [
  //{path: "", component: MainComponent},
  {path: "main", component: MainComponent, canActivate: [isLoggedGuard]},
  {path: "login", component: LoginComponent},
  {path: "registry", component: RegistrationComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
