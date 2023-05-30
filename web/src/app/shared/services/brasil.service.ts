import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Cep} from "@shared/interfaces/Cep";
import {lastValueFrom} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class BrasilService {
  private readonly apiUrl = 'https://brasilapi.com.br/api';

  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  fetchCep(cep: string) {
    return lastValueFrom(
      this.httpClient.get<Cep>(`${this.apiUrl}/cep/v2/${cep}`)
    );
  }
}
