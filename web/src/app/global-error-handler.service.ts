import {ErrorHandler, Injectable} from "@angular/core";
import {HttpErrorResponse, HttpStatusCode} from "@angular/common/http";
import {Router} from "@angular/router";

@Injectable()
export class GlobalErrorHandlerService implements ErrorHandler {
  constructor(
    private readonly router: Router
  ) {
  }

  async handleError(error: any) {
    if (error instanceof HttpErrorResponse) {
      switch (error.status) {
        case HttpStatusCode.Unauthorized:
          await this.router.navigateByUrl("/login");
          break;
      }
    }
  }
}
