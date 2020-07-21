import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { BehaviorSubject } from 'rxjs';

import { BaseService } from "../services/base.service";
import { ConfigService } from '../services/config.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpService } from '../services/http.service';

@Injectable()
export class AuthService {
  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);

  /**
 * JWT helper service to get the token information
 */
  private _jwtHelper = new JwtHelperService();

  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();
  private manager = new UserManager(this.getClientSettings());
  private user: User | null;
  private test = "";

  constructor(private httpService: HttpService, private configService: ConfigService) {

    // this.configService.settingsLoaded$.subscribe(x => {
    //   this.test = this.configService.serverSettings.clientBaseUri;
    // });

    this.manager.getUser().then(user => {
      this.user = user;
      this._authNavStatusSource.next(this.isAuthenticated());
    });
  }

  login() {
    return this.manager.signinRedirect();
  }

  async completeAuthentication() {
    this.user = await this.manager.signinRedirectCallback();
    this._authNavStatusSource.next(this.isAuthenticated());
  }

  register(userRegistration: any) {
    var test = {
      "BuyerId": "sasasasas43434",
      "BasketItems": []
    }
    return this.httpService.post("https://localhost:44331/api/v1/b/update", test)
      .pipe(map(response => {
        return response;
      }));
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  isAuthenticatedByJwtHelper(): boolean {
    if (this._authNavStatusSource.value) {
      const token = this.user.access_token;
      // Check whether the token is expired and return
      // true or false
      return !this._jwtHelper.isTokenExpired(token);
    }
    else
      return false;
  }

  decodeToken(): boolean {
    if (this._authNavStatusSource.value) {
      const token = this.user.access_token;
      // Check whether the token is expired and return
      // true or false
      return this._jwtHelper.decodeToken(token);
    }
    else
      return false;
  }

  get authorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  get authorizationToken(): string {
    return `${this.user.access_token}`;
  }

  get name(): string {
    return this.user != null ? this.user.profile.unique_name : '';
  }

  get userInfo() {
    return this.user;
  }

  async signout() {
    await this.manager.signoutRedirect();
  }

  private getClientSettings(): UserManagerSettings {
    return {
      authority: "https://localhost:44304/",
      client_id: 'angular_spa',
      redirect_uri: `${"http://localhost:4200"}/auth-callback`,
      post_logout_redirect_uri: "http://localhost:4200",
      response_type: "code",
      scope: "openid profile catalog basket",
      filterProtocolClaims: true,
      loadUserInfo: true
    };
  }
}


