import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {RegisterService} from "./register.service";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent {
  formGroup: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly registerService: RegisterService,
    private readonly router: Router
  ) {
    this.formGroup = this.getFormGroup();
  }

  getFormGroup() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      passwordConfirmation: [null, Validators.required],
      role: ['Admin']
    });
  }

  submitForm() {
    this.formGroup.markAllAsTouched();

    if (this.formGroup.invalid) {
      return;
    }

    const {name, email, password, passwordConfirmation, role} = this.formGroup.getRawValue();

    this.registerService.createUser({
      name, email, password, passwordConfirmation, role
    }).subscribe({
      complete: () => {
        this.router.navigateByUrl('/login');
      },
      error: (httpErrorResponse: HttpErrorResponse) => {
        if (httpErrorResponse.error.errors && typeof(httpErrorResponse.error.errors) === 'object') {
          this.formGroup.setErrors(httpErrorResponse.error.errors);
        }
      }
    });
  }
}
