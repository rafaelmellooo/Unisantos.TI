import {NgModule} from "@angular/core";
import {WarningDialogComponent} from './components/warning-dialog/warning-dialog.component';
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogModule} from "@angular/material/dialog";
import { HeaderComponent } from './components/header/header.component';
import {RouterLink} from "@angular/router";

@NgModule({
  declarations: [
    WarningDialogComponent,
    HeaderComponent
  ],
  imports: [
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    RouterLink
  ],
  exports: [
    HeaderComponent
  ]
})
export class SharedModule {
}
