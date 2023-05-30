import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Company} from "@shared/interfaces/Company";
import {environment} from "@env/environment";
import {lastValueFrom} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getAdminCompanies() {
    return lastValueFrom(
      this.httpClient.get<Company[]>(`${environment}/admin/companies`)
    );
  }
}
