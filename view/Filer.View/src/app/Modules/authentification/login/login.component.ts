import { Component } from '@angular/core';
import { AuthService } from '../../../Services/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./../authentification.styles.css','./login.component.css']
})
export class LoginComponent {
  constructor(private auth: AuthService) {}

  public form: FormGroup = new FormGroup({
    login: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)]),
    password: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)])
  });
  public errorText: string = "";
  onTyping(){
    this.errorText = "";
  }
  Login(){
    if(!this.form.valid){
      let loginErrors = this.form.get("login")?.errors;
      let passwordErrors = this.form.get("password")?.errors;
      if(loginErrors?.["required"] || passwordErrors?.["required"]){
        this.errorText = "Заполните логин и пароль!";
        return;
      }
      if(loginErrors?.["minlength"] || passwordErrors?.["minlength"]){
        this.errorText = "Логин и пароль должны содержать хотя бы 3 символа!";
        return;
      }
      if(loginErrors?.["maxlength"] || passwordErrors?.["maxlength"]){
        this.errorText = "Логин или пароль слишком длинные!";
        return;
      }
      this.errorText = "Ошибка";
      return;
    }
    this.auth.Login(this.form.get("login")?.value, this.form.get("password")?.value)
    .subscribe(succes => {
      if(!succes){
        this.errorText = "Попытка входа не удалась.";
      }
    });
  }
}
