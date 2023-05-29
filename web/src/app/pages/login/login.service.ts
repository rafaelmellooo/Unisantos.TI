import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SuccessResponse} from "../../shared/interfaces/SuccessResponse";

interface CreateSessionData {
  email: string;
  password: string;
}

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
    return this.httpClient.post<SuccessResponse<SessionResponse>>('https://localhost:7111/sessions', createSessionData);
  }
}
