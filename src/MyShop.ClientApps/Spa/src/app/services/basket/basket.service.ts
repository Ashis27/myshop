import { Injectable, OnInit } from '@angular/core';
import { IBasket } from 'src/app/shared/models/basket.model';
import { Subject, Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http.service';
import { AuthService } from 'src/app/shared/authentication/auth.service';
import { Router } from '@angular/router';
import { ConfigService } from 'src/app/shared/services/config.service';
import { StorageService } from 'src/app/shared/services/storage.service';
import { IBasketCheckout } from 'src/app/shared/models/basketCheckout.model';
import { IOrder } from 'src/app/shared/models/order.model';
import { map } from 'rxjs/operators';
import { BasketWrapperService } from 'src/app/shared/services/basket.wrapper.service';

@Injectable()
export class BasketService {
  private basketUrl: string = '';
  private purchaseUrl: string = '';
  basket: IBasket = {
      buyerId: '',
      basketItems: []
  };

  //observable that is fired when the basket is dropped
  private basketDropedSource = new Subject();
  basketDroped$ = this.basketDropedSource.asObservable();
  
  constructor(private basketEvents:BasketWrapperService, private service: HttpService, private authService: AuthService, private router: Router, private configurationService: ConfigService, private storageService: StorageService) {
      this.basket.basketItems = [];
      
      // Init:
      if (this.authService.isAuthenticated) {
          if (this.authService.userInfo) {
              this.basket.buyerId = this.authService.userInfo.profile.sub;
              if (this.configurationService.isReady) {
                  this.basketUrl = this.configurationService.serverSettings.purchaseUrl; 
                  this.purchaseUrl = this.configurationService.serverSettings.purchaseUrl;
                  this.loadData();
              }
              else {
                  this.configurationService.settingsLoaded$.subscribe(x => {
                      this.basketUrl = this.configurationService.serverSettings.purchaseUrl;
                      this.purchaseUrl = this.configurationService.serverSettings.purchaseUrl;
                      this.loadData();
                  });
              }
          }
      }

      this.basketEvents.orderCreated$.subscribe(x => {
          this.dropBasket();
      });
  }
  
  addItemToBasket(item): Observable<boolean> {
      this.basket.basketItems.push(item);
      return this.setBasket(this.basket);
  }

  setBasket(basket): Observable<boolean> {
      let url = this.purchaseUrl + 'api/v1/b/update';
      this.basket = basket;
      this.basket.buyerId = this.authService.userInfo.profile.sub;
      return this.service.post(url, basket).pipe(map((response: any) => {
          return true;
      }));
  }

  setBasketCheckout(basketCheckout): Observable<boolean> {
      let url = this.basketUrl + 'api/v1/b/checkout';
      return this.service.post(url, basketCheckout).pipe(map((response: any) => {
          this.basketEvents.orderCreated();
          return true;
      }));
  }

  getBasket(): Observable<IBasket> {
      let url = this.basketUrl + 'api/v1/b/' + this.basket.buyerId;
      return this.service.get(url).pipe(map((response: any) => {
          if (response.status === 204) {
              return null;
          }
          return response;
      }));
  }    

  mapBasketInfoCheckout(order: IOrder): IBasketCheckout {
      let basketCheckout = <IBasketCheckout>{};

      basketCheckout.street = order.street
      basketCheckout.city = order.city;
      basketCheckout.country = order.country;
      basketCheckout.state = order.state;
      basketCheckout.zipcode = order.zipcode;
      basketCheckout.cardexpiration = order.cardexpiration;
      basketCheckout.cardnumber = order.cardnumber;
      basketCheckout.cardsecuritynumber = order.cardsecuritynumber;
      basketCheckout.cardtypeid = order.cardtypeid;
      basketCheckout.cardholdername = order.cardholdername;
      basketCheckout.total = 0;
      basketCheckout.expiration = order.expiration;

      return basketCheckout;
  }    

  dropBasket() {
      this.basket.basketItems = [];        
      this.basketDropedSource.next();
  }

  private loadData() {
      this.getBasket().subscribe(basket => {
          if (basket != null)
              this.basket.basketItems = basket.basketItems;
      });
  }
}
