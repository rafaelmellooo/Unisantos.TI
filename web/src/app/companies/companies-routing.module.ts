import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {NewCompanyComponent} from "./pages/new-company/new-company.component";

const routes: Routes = [
  {
    path: 'new',
    component: NewCompanyComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompaniesRoutingModule {
}
