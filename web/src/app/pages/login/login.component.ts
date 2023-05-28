import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {LoginService} from "./login.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  formGroup: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly loginService: LoginService,
    private readonly router: Router
  ) {
    this.formGroup = this.getFormGroup();
  }

  getFormGroup() {
    return this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required]
    });
  }

  submitForm() {
    this.formGroup.markAllAsTouched();

    if (this.formGroup.invalid) {
      return;
    }

    const {email, password} = this.formGroup.getRawValue();

    this.loginService.createSession({
      email, password
    }).subscribe(response => {
      localStorage.setItem('token', response.data.token);

      this.router.navigateByUrl('/home');
    });
  }
}
