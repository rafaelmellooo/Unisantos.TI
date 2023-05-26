import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {CompanyResponse} from "../../shared/interfaces/CompanyResponse";

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getAdminCompanies() {
    return this.httpClient.get<CompanyResponse[]>('https://localhost:7111/admin/companies');
  }
}
