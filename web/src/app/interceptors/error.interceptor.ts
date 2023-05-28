import {Injectable} from "@angular/core";
import {HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode} from "@angular/common/http";
import {catchError, throwError} from "rxjs";
import {WarningDialogComponent} from "../shared/components/warning-dialog/warning-dialog.component";
import {Router} from "@angular/router";
import {MatDialog} from "@angular/material/dialog";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private readonly router: Router,
    private readonly dialog: MatDialog
  ) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    return next.handle(request).pipe(
      catchError((httpErrorResponse: HttpErrorResponse) => {
        switch (httpErrorResponse.status) {
          case HttpStatusCode.BadRequest:
            if (httpErrorResponse.error.message && typeof(httpErrorResponse.error.message) === 'string') {
              this.dialog.open(WarningDialogComponent, {
                data: {
                  content: httpErrorResponse.error.message
                }
              });
            }

            break;

          case HttpStatusCode.Unauthorized:
            this.router.navigateByUrl("/login");
            break;
        }

        return throwError(() => httpErrorResponse);
      })
    );
  }
}
