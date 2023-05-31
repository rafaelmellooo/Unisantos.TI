import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {CompanyService} from "../../companies/services/company.service";
import {Company} from "@shared/interfaces/Company/Company";
import {MatPaginator} from "@angular/material/paginator";
import {MatTableDataSource} from "@angular/material/table";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit, AfterViewInit {
  companies = new Array<Company>();
  dataSource = new MatTableDataSource<Company>();

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(
    private readonly companyService: CompanyService
  ) {
  }

  ngOnInit(): void {
    this.loadAdminCompanies().then(() => {
      this.dataSource.data = this.companies;
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
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
