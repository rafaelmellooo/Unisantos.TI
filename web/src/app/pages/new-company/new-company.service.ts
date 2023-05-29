import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "../../shared/interfaces/SuccessResponse";
import {TagsSection} from "../../shared/interfaces/TagsSection";
import {environment} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class NewCompanyService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getTags() {
    return this.httpClient.get<SuccessResponse<TagsSection[]>>(`${environment.apiUrl}tags`);
  }

  createCompany(company: any) {
    return this.httpClient.post<SuccessResponse<any>>(`${environment.apiUrl}companies`, company);
  }
}
