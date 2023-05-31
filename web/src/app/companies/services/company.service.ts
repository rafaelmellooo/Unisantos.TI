import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "@shared/interfaces/SuccessResponse";
import {TagSection} from "@shared/interfaces/Company/TagSection";
import {environment} from "@env/environment";
import {lastValueFrom} from "rxjs";
import {CompanyData} from "@shared/interfaces/Company/CompanyData";

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

  createCompany(companyData: CompanyData) {
    return lastValueFrom(
      this.httpClient.post<SuccessResponse<any>>(`${environment.apiUrl}/companies`, companyData)
    );
  }

  getCompanyDetails(id: string) {
    return lastValueFrom(
      this.httpClient.get<SuccessResponse<CompanyData>>(`${environment.apiUrl}/companies/${id}`)
    );
  }

  updateCompany(id: string, companyData: CompanyData) {
    return lastValueFrom(
      this.httpClient.put<void>(`${environment.apiUrl}/companies/${id}`, companyData)
    );
  }
}
