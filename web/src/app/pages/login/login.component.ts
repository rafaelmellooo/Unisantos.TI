import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {LoginService} from "./login.service";
import {Router} from "@angular/router";
import {CreateSessionData} from "@shared/interfaces/CreateSessionData";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  sessionForm: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly loginService: LoginService,
    private readonly router: Router
  ) {
    this.sessionForm = this.createSessionForm();
  }

  createSessionForm() {
    return this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required]
    });
  }

  async submitForm() {
    this.sessionForm.markAllAsTouched();

    if (this.sessionForm.invalid) {
      return;
    }

    const sessionData = this.sessionForm.getRawValue() as CreateSessionData;

    const response = await this.loginService.createSession(sessionData);

    localStorage.setItem('token', response.data.token);

    this.router.navigateByUrl('/home');
  }
}
