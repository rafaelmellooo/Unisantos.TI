import {NgModule} from "@angular/core";
import {WarningDialogComponent} from './components/warning-dialog/warning-dialog.component';
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
  declarations: [
    WarningDialogComponent
  ],
    imports: [
        MatIconModule,
        MatButtonModule,
        MatDialogModule
    ],
})
export class SharedModule {
}
