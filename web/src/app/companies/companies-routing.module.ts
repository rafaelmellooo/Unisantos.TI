import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {NewCompanyComponent} from "./pages/new-company/new-company.component";

const routes: Routes = [
  {
    path: 'new',
    component: NewCompanyComponent,
    data: {
      viewMode: false,
      updateMode: false
    }
  },
  {
    path: ':id',
    component: NewCompanyComponent,
    data: {
      viewMode: true,
      updateMode: false
    }
  },
  {
    path: ':id/update',
    component: NewCompanyComponent,
    data: {
      viewMode: false,
      updateMode: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompaniesRoutingModule {
}
