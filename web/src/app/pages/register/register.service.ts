import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {environment} from "@env/environment";
import {lastValueFrom} from "rxjs";
import {CreateUserData} from "@shared/interfaces/CreateUserData";

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  createUser(createUserData: CreateUserData) {
    return lastValueFrom(
      this.httpClient.post<void>(`${environment.apiUrl}/users`, createUserData)
    );
  }
}
