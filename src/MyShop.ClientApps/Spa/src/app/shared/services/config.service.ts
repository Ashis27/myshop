import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { map } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { IConfiguration } from '../models/configuration.model';
import { StorageService } from './storage.service';
import { NotificationService } from './notification.service';
import { UserManagerSettings } from 'oidc-client';

@Injectable()
export class ConfigService {
    serverSettings: IConfiguration;
    isReady: boolean = false;

    private settingLoadedSource = new Subject();
    settingsLoaded$ = this.settingLoadedSource.asObservable();


    constructor(private httpService: HttpService, private storageService: StorageService,
        private notificationService: NotificationService) {
    }

    load() {
        const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
        // let url = `${baseURI}Home/Configuration`;
        // return this.httpService.get("https://jsonplaceholder.typicode.com/todos")
        //     .subscribe((response: any) => {
        var res = {
            identityUrl: "https://localhost:44304/",
            purchaseUrl: "https://localhost:44331/",
            signalrHubUrl: "http://localhost:7009/",
            clientBaseUri: baseURI
        } as IConfiguration;
        this.serverSettings = res;
        this.storageService.store('identityUrl', this.serverSettings.identityUrl);
        this.storageService.store('purchaseUrl', this.serverSettings.purchaseUrl);
        this.storageService.store('signalrHubUrl', this.serverSettings.signalrHubUrl);
        this.storageService.store('clientBaseUri', this.serverSettings.clientBaseUri);
        this.isReady = true;
        this.settingLoadedSource.next();
        // },
        //     error => {
        //         this.notificationService.errorMessage(error);
        //     });
    }
}