import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";

interface CreateSessionData {
  email: string;
  password: string;
}

interface SessionResponse {
  data: {
    token: string;
  }
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
    return this.httpClient.post<SessionResponse>('https://localhost:7111/sessions', createSessionData);
  }
}
