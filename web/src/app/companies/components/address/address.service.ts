import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "@shared/interfaces/SuccessResponse";
import {State} from "@shared/interfaces/Address/State";
import {environment} from "@env/environment";
import {City} from "@shared/interfaces/Address/City";
import {lastValueFrom} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  getStates() {
    return lastValueFrom(
      this.httpClient.get<SuccessResponse<State[]>>(`${environment.apiUrl}/states`)
    );
  }

  getCities(state: string) {
    return lastValueFrom(
      this.httpClient.get<SuccessResponse<City[]>>(`${environment.apiUrl}/states/${state}/cities`)
    );
  }
}
