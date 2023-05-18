import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {WarningDialogComponent} from "../../shared/components/warning-dialog/warning-dialog.component";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  formGroup: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
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
    this.dialog.open(WarningDialogComponent, {
      data: {
        content: 'E-mail e/ou senha inválidos'
      }
    });
  }
}
