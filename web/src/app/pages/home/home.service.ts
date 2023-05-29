import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Company} from "../../shared/interfaces/Company";

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getAdminCompanies() {
    return this.httpClient.get<Company[]>('https://localhost:7111/admin/companies');
  }
}
