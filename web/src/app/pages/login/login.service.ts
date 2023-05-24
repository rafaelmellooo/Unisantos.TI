import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";

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

  createSession(sessionData: CreateSessionData) {
    return this.httpClient.post<SessionResponse>('', sessionData);
  }
}
