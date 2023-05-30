import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

interface ErrorDialogData {
  warning: string;
}

@Component({
  selector: 'app-warning-dialog',
  templateUrl: './warning-dialog.component.html',
  styleUrls: ['./warning-dialog.component.sass']
})
export class WarningDialogComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public readonly data: ErrorDialogData
  ) {
  }
}
