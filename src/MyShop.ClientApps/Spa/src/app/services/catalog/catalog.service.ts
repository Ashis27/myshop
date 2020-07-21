import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICatalog } from 'src/app/shared/models/catalog.model';
import { HttpService } from 'src/app/shared/services/http.service';
import { map } from 'rxjs/operators';
import { ConfigService } from 'src/app/shared/services/config.service';

@Injectable()
export class CatalogService {
  private catalogUrl: string;

  constructor(private httpService: HttpService, private configService: ConfigService) {
    // this.configService.settingsLoaded$.subscribe((res) => {
    //   this.catalogUrl = this.configService.serverSettings.purchaseUrl + "/api/v1/c/items";
    // })
    this.catalogUrl = this.configService.serverSettings.purchaseUrl + "api/v1/c/items";
  }

  getCatalog(pageSize: number, pageIndex: number, brand: number, type: number): Observable<ICatalog> {
    let url = this.catalogUrl;

    if (type) {
      url = this.catalogUrl + '/type/' + type.toString() + '/brand/' + ((brand) ? brand.toString() : '');
    }
    else if (brand) {
      url = this.catalogUrl + '/type/all' + '/brand/' + ((brand) ? brand.toString() : '');
    }

    url = url + '?pageSize=' + pageSize + '&pageIndex=' + pageIndex;

    return this.httpService.get(url)
      .pipe(map((response: any) => {
        return response;
      })
      );
  }
}
