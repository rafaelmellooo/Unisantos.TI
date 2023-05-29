import {NgModule} from "@angular/core";
import {WarningDialogComponent} from './components/warning-dialog/warning-dialog.component';
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogModule} from "@angular/material/dialog";
import { HeaderComponent } from './components/header/header.component';
import {RouterLink} from "@angular/router";
import { AddressComponent } from './components/address/address.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatOptionModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import {NgForOf} from "@angular/common";
import {NgxMaskDirective} from "ngx-mask";
import { BusinessHoursComponent } from './components/business-hours/business-hours.component';
import { ProductsSectionsComponent } from './components/products-sections/products-sections.component';

@NgModule({
  declarations: [
    WarningDialogComponent,
    HeaderComponent,
    AddressComponent,
    BusinessHoursComponent,
    ProductsSectionsComponent
  ],
  imports: [
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    RouterLink,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    NgForOf,
    NgxMaskDirective,
    ReactiveFormsModule
  ],
  exports: [
    HeaderComponent,
    AddressComponent,
    BusinessHoursComponent,
    ProductsSectionsComponent
  ]
})
export class SharedModule {
}
