import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "@shared/interfaces/SuccessResponse";
import {TagSection} from "@shared/interfaces/Company/TagSection";
import {environment} from "@env/environment";
import {lastValueFrom} from "rxjs";
import {CompanyData} from "@shared/interfaces/Company/CompanyData";
import {CreateCompanyData} from "@shared/interfaces/Company/CreateCompanyData";
import {UpdateCompanyData} from "@shared/interfaces/Company/UpdateCompanyData";
import {Company} from "@shared/interfaces/Company/Company";

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getTags() {
    return lastValueFrom(
      this.httpClient.get<SuccessResponse<TagSection[]>>(`${environment.apiUrl}/tags`)
    );
  }

  getAdminCompanies() {
    return lastValueFrom(
      this.httpClient.get<Company[]>(`${environment}/admin/companies`)
    );
  }

  getCompanyDetails(id: string) {
    return lastValueFrom(
      this.httpClient.get<SuccessResponse<CompanyData>>(`${environment.apiUrl}/companies/${id}`)
    );
  }

  createCompany(createCompanyData: CreateCompanyData) {
    return lastValueFrom(
      this.httpClient.post<SuccessResponse<any>>(`${environment.apiUrl}/companies`, createCompanyData)
    );
  }

  updateCompany(id: string, updateCompanyData: UpdateCompanyData) {
    return lastValueFrom(
      this.httpClient.put<void>(`${environment.apiUrl}/companies/${id}`, updateCompanyData)
    );
  }
}
