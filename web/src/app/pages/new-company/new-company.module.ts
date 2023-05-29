import {NgModule} from "@angular/core";
import {NewCompanyComponent} from "./new-company.component";
import {AddressComponent} from "./components/address/address.component";
import {BusinessHoursComponent} from "./components/business-hours/business-hours.component";
import {ProductsSectionsComponent} from "./components/products-sections/products-sections.component";
import {SharedModule} from "../../shared/shared.module";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {NgxMaskDirective, NgxMaskPipe, provideNgxMask} from "ngx-mask";
import {MatButtonModule} from "@angular/material/button";
import {ReactiveFormsModule} from "@angular/forms";
import {CommonModule} from "@angular/common";
import {MatIconModule} from "@angular/material/icon";

@NgModule({
  declarations: [
    NewCompanyComponent,
    AddressComponent,
    BusinessHoursComponent,
    ProductsSectionsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatInputModule,
    MatSelectModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MatButtonModule,
    ReactiveFormsModule,
    MatIconModule
  ],
  providers: [
    provideNgxMask()
  ],
})
export class NewCompanyModule {
}
