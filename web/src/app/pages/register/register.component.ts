import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {RegisterService} from "./register.service";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";
import {CreateUserData} from "@shared/interfaces/CreateUserData";
import {UserRole} from "@shared/enums/UserRole";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly registerService: RegisterService,
    private readonly router: Router
  ) {
    this.registerForm = this.createRegisterForm();
  }

  createRegisterForm() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      passwordConfirmation: [null, Validators.required],
      role: [UserRole.Admin]
    });
  }

  async submitForm() {
    this.registerForm.markAllAsTouched();

    if (this.registerForm.invalid) {
      return;
    }

    const userData = this.registerForm.getRawValue() as CreateUserData;

    try {
      await this.registerService.createUser(userData);

      this.router.navigateByUrl('/login');
    } catch (exception) {
      if (exception instanceof HttpErrorResponse) {
        if (exception.error.errors && typeof(exception.error.errors) === 'object') {
          this.registerForm.setErrors(exception.error.errors);
        }
      }
    }
  }
}
