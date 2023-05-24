import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {WarningDialogComponent} from "../../shared/components/warning-dialog/warning-dialog.component";
import {LoginService} from "./login.service";
import {HttpErrorResponse} from "@angular/common/http";

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
    private readonly dialog: MatDialog
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
    }).subscribe({
      next: response => {
        localStorage.setItem('token', response.token);
      },
      error: (error: HttpErrorResponse) => {
        this.dialog.open(WarningDialogComponent, {
          data: {
            content: error.message
          }
        });
      }
    });
  }
}
