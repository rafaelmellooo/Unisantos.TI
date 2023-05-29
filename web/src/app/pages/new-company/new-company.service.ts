import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "../../shared/interfaces/SuccessResponse";
import {TagsSectionResponse} from "../../shared/interfaces/TagsSectionResponse";
import {StateResponse} from "../../shared/interfaces/StateResponse";
import {CityResponse} from "../../shared/interfaces/CityResponse";

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

  getStates() {
    return this.httpClient.get<SuccessResponse<StateResponse[]>>('https://localhost:7111/states');
  }

  getCities(stateId: number) {
    return this.httpClient.get<SuccessResponse<CityResponse[]>>(`https://localhost:7111/states/${stateId}/cities`);
  }
}
