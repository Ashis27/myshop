import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../authentication/auth.service';


/**
 * Error interceptor
 */
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    /**
     * @ignore
     */
    constructor(private authenticationService: AuthService) { }

    /**
     *Throw error while throwing any error from API
     *@example
     *intercept()
     *@returns {void}
     */
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
        if (navigator.onLine)
            return next.handle(request).pipe(catchError(err => {
                var applicationError = err.headers.get('Application-Error');

                // either application-error in header or model error in body
                if (applicationError) {
                    return throwError(applicationError);
                }

                if ([401, 403].indexOf(err.status) !== -1) {
                    // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
                    this.authenticationService.signout();
                    window.location.href = "/";
                    return throwError("You login session has expired.");
                }

                if (err.status === 400)
                {
                    return throwError(err.error.message);
                }

                var modelStateErrors: string = '';

                // for now just concatenate the error descriptions, alternative we could simply pass the entire error response upstream
                for (var key in err.error) {
                    if (err.error[key]) modelStateErrors += err.error[key].description + '\n';
                }

                modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
                
                return throwError(modelStateErrors || 'Server error');
            }));
        else
            return Observable.throw("Please check you network connectivity.");
    }
}