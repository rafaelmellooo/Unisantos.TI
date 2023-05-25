import {HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {NgxSpinnerService} from "ngx-spinner";
import {finalize} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(
    private readonly spinnerService: NgxSpinnerService
  ) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    this.spinnerService.show();

    return next.handle(request).pipe(
      finalize(() => {
        this.spinnerService.hide();
      })
    );
  }
}
