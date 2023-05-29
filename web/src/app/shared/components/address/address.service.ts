import {Injectable} from "@angular/core";
import {SuccessResponse} from "../../interfaces/SuccessResponse";
import {StateResponse} from "../../interfaces/StateResponse";
import {CityResponse} from "../../interfaces/CityResponse";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getStates() {
    return this.httpClient.get<SuccessResponse<StateResponse[]>>('https://localhost:7111/states');
  }

  getCities(stateId: number) {
    return this.httpClient.get<SuccessResponse<CityResponse[]>>(`https://localhost:7111/states/${stateId}/cities`);
  }
}
