import {Component, OnInit} from '@angular/core';
import {CompanyService} from "../../companies/services/company.service";
import {Company} from "@shared/interfaces/Company/Company";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  companies = new Array<Company>();

  constructor(
    private readonly companyService: CompanyService
  ) {
  }

  ngOnInit(): void {
    this.loadAdminCompanies();
  }

  async loadAdminCompanies() {
    const response = await this.companyService.getAdminCompanies();

    this.companies = response.data;
  }

  async removeCompany(id: string) {
    await this.companyService.deleteCompany(id);

    this.companies = this.companies.filter(company => company.id !== id);
  }
}
