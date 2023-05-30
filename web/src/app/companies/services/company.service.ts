import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "@shared/interfaces/SuccessResponse";
import {TagSection} from "@shared/interfaces/TagSection";
import {environment} from "@env/environment";
import {lastValueFrom} from "rxjs";

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

  createCompany(company: any) {
    return lastValueFrom(
      this.httpClient.post<SuccessResponse<any>>(`${environment.apiUrl}/companies`, company)
    );
  }
}
