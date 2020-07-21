// include directives/components commonly used in features modules in this shared modules
// and import me into the feature module
// importing them individually results in: Type xxx is part of the declarations of 2 modules: ... Please consider moving to a higher module...
// https://github.com/angular/angular/issues/10646  

import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgxSpinnerModule } from 'ngx-spinner';
import { AutofocusDirective } from './directives/auto-focus.directive';
import { UpperCasePipe } from './pipes/upper-case.pipe';
import { AppLayoutComponent } from './components/app-layout.component';
import { ConfigService } from './services/config.service';
import { HeaderComponent } from './components/navbar/header.component';
import { HttpService } from './services/http.service';
import { StorageService } from './services/storage.service';
import { NotificationService } from './services/notification.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { AuthService } from './authentication/auth.service';

//https://stackoverflow.com/questions/41433766/directive-doesnt-work-in-a-sub-module
//https://stackoverflow.com/questions/45032043/uncaught-error-unexpected-module-formsmodule-declared-by-the-module-appmodul/45032201

@NgModule({
  imports: [CommonModule, NgxSpinnerModule],
  declarations: [
    AutofocusDirective,
    UpperCasePipe,
    AppLayoutComponent,
    HeaderComponent
  ],
  exports: [NgxSpinnerModule, AutofocusDirective],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    // { provide: HTTP_INTERCEPTORS, useClass: LoadingScreenInterceptor, multi: true },
    ConfigService,
    HttpService,
    StorageService,
    NotificationService,
    AuthService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedModule { }