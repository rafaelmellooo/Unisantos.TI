import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

interface CreateUserData {
  name: string;
  email: string;
  password: string;
  passwordConfirmation: string;
  role: string;
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  constructor(
    private readonly httpClient: HttpClient
  ) {
  }

  createUser(createUserData: CreateUserData) {
    return this.httpClient.post<void>('https://localhost:7111/users', createUserData);
  }
}
