import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "../../shared/interfaces/SuccessResponse";
import {TagsSectionResponse} from "../../shared/interfaces/TagsSectionResponse";

@Injectable({
  providedIn: 'root'
})
export class NewCompanyService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getTags() {
    return this.httpClient.get<SuccessResponse<TagsSectionResponse[]>>('https://localhost:7111/tags');
  }

  createCompany(company: any) {
    return this.httpClient.post<SuccessResponse<any>>('https://localhost:7111/companies', company);
  }
}
