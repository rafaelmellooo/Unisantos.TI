import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CompaniesRoutingModule} from './companies-routing.module';
import {SharedModule} from "@shared/shared.module";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {NgxMaskDirective, NgxMaskPipe} from "ngx-mask";
import {MatButtonModule} from "@angular/material/button";
import {ReactiveFormsModule} from "@angular/forms";
import {MatIconModule} from "@angular/material/icon";
import {NewCompanyComponent} from "./pages/new-company/new-company.component";
import {AddressComponent} from "./components/address/address.component";
import {BusinessHoursComponent} from "./components/business-hours/business-hours.component";
import {ProductSectionsComponent} from "./components/product-sections/product-sections.component";


@NgModule({
  declarations: [
    NewCompanyComponent,
    AddressComponent,
    BusinessHoursComponent,
    ProductSectionsComponent
  ],
  imports: [
    CompaniesRoutingModule,
    CommonModule,
    SharedModule,
    MatInputModule,
    MatSelectModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MatButtonModule,
    ReactiveFormsModule,
    MatIconModule
  ]
})
export class CompaniesModule {
}
