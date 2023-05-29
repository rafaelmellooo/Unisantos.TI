import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "../../shared/interfaces/SuccessResponse";
import {TagsSection} from "../../shared/interfaces/TagsSection";

@Injectable({
  providedIn: 'root'
})
export class NewCompanyService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getTags() {
    return this.httpClient.get<SuccessResponse<TagsSection[]>>('https://localhost:7111/tags');
  }

  createCompany(company: any) {
    return this.httpClient.post<SuccessResponse<any>>('https://localhost:7111/companies', company);
  }
}
