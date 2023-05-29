import {Injectable} from "@angular/core";
import {SuccessResponse} from "../../../../shared/interfaces/SuccessResponse";
import {State} from "../../../../shared/interfaces/State";
import {City} from "../../../../shared/interfaces/City";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getStates() {
    return this.httpClient.get<SuccessResponse<State[]>>(`${environment.apiUrl}states`);
  }

  getCities(stateId: number) {
    return this.httpClient.get<SuccessResponse<City[]>>(`${environment.apiUrl}states/${stateId}/cities`);
  }
}
