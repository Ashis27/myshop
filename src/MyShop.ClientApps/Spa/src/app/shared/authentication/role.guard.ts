import { Injectable } from '@angular/core';
import {
    CanActivate,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';
import { AuthService } from './auth.service';


/**
 * Role based guard service
 */
@Injectable()
export class RoleGuardService implements CanActivate {
    /**
     * @ignore
     */
    constructor(private _authenticationService: AuthService) { }

    /**
     * To check current role auth status while page redirection
     * @example
     * canActivate()
     * @returns {boolean} True | False
     */
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        // this will be passed from the route config
        // on the data property
        let expectedRole = "";

        if (!route.data || !route.data.expectedRole || route.data.expectedRole.length == 0) {
            this._authenticationService.signout();
            // this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
            return false;
        }

        let isAuthenticated = false;

        route.data.expectedRole.forEach(element => {
            expectedRole = element;
            const token = this._authenticationService.authorizationToken;

            // decode the token to get its payload
            const tokenPayload: any = this._authenticationService.decodeToken();

            if (this._authenticationService.isAuthenticated() && tokenPayload.role == expectedRole) {
                isAuthenticated = true;
            }

        });

        if (!isAuthenticated) {
            this._authenticationService.signout();
            //this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
            return false;
        }

        return true;
    }
}