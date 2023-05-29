import {Injectable} from "@angular/core";
import {SuccessResponse} from "../../../../shared/interfaces/SuccessResponse";
import {State} from "../../../../shared/interfaces/State";
import {City} from "../../../../shared/interfaces/City";
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
    return this.httpClient.get<SuccessResponse<State[]>>('https://localhost:7111/states');
  }

  getCities(stateId: number) {
    return this.httpClient.get<SuccessResponse<City[]>>(`https://localhost:7111/states/${stateId}/cities`);
  }
}
