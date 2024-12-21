import { Component } from '@angular/core';
import { AuthService } from '../../../Services/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private auth: AuthService) {}

  public form: FormGroup = new FormGroup({
    login: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)]),
    password: new FormControl("", [Validators.required, Validators.maxLength(50), Validators.minLength(3)])
  });
  public errorText: string = "";
  Login(){
    if(!this.form.valid){
      this.errorText = "error";
      return;
    }
    this.auth.Login(this.form.get("login")?.value, this.form.get("password")?.value);
  }
}
