import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../Services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./../authentification.styles.css','./registration.component.css']
})
export class RegistrationComponent {
constructor(private auth: AuthService) {}

  public form: FormGroup = new FormGroup({
    login: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)]),
    username: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)]),
    password: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)])
  });
  public errorText: string = "";
  onTyping(){
    this.errorText = "";
  }
  Registry(){
    if(!this.form.valid){
      let loginErrors = this.form.get("login")?.errors;
      let passwordErrors = this.form.get("password")?.errors;
      let usernameErrors = this.form.get("username")?.errors;
      if(loginErrors?.["required"] || passwordErrors?.["required"] || usernameErrors?.["required"]){
        this.errorText = "Заполните логин, имя пользователя и пароль!";
        return;
      }
      if(loginErrors?.["minlength"] || passwordErrors?.["minlength"] || usernameErrors?.["minlength"]){
        this.errorText = "Логин, имя пользователя и пароль должны содержать хотя бы 3 символа!";
        return;
      }
      if(loginErrors?.["maxlength"] || passwordErrors?.["maxlength"] || usernameErrors?.["maxlength"]){
        this.errorText = "Логин, имя пользователя или пароль слишком длинные!";
        return;
      }
      this.errorText = "Ошибка";
      return;
    }
    this.auth.Register(this.form.get("login")?.value, 
      this.form.get("username")?.value, 
      this.form.get("password")?.value).subscribe(result => {
        if(!result){
          this.errorText = "Данный логин занят.";
        }
      });
  }
}
