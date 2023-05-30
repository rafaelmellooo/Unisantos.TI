import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "@shared/interfaces/SuccessResponse";
import {environment} from "@env/environment";
import {lastValueFrom} from "rxjs";
import {CreateSessionData} from "@shared/interfaces/CreateSessionData";

interface SessionResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  createSession(createSessionData: CreateSessionData) {
    return lastValueFrom(
      this.httpClient.post<SuccessResponse<SessionResponse>>(`${environment.apiUrl}/sessions`, createSessionData)
    );
  }
}
