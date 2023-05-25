import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

interface ErrorDialogData {
  content: string;
}

@Component({
  selector: 'app-warning-dialog',
  templateUrl: './warning-dialog.component.html',
  styleUrls: ['./warning-dialog.component.sass']
})
export class WarningDialogComponent {
  constructor(
    private readonly dialogRef: MatDialogRef<WarningDialogComponent>,

    @Inject(MAT_DIALOG_DATA)
    public readonly data: ErrorDialogData
  ) {
  }
}
