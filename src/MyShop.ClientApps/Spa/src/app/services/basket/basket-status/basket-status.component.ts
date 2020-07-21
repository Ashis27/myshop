import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { BasketService } from '../basket.service';
import { ConfigService } from 'src/app/shared/services/config.service';
import { BasketWrapperService } from 'src/app/shared/services/basket.wrapper.service';
import { AuthService } from 'src/app/shared/authentication/auth.service';

@Component({
  selector: 'app-basket-status',
  templateUrl: './basket-status.component.html',
  styleUrls: ['./basket-status.component.sass']
})
export class BasketStatusComponent implements OnInit {
  basketItemAddedSubscription: Subscription;
  authSubscription: Subscription;
  basketDroppedSubscription: Subscription;

  badge: number = 0;

  constructor(private authService: AuthService, private basketEvents: BasketWrapperService, private service: BasketService, private configurationService: ConfigService) { }

  ngOnInit() {
    // Subscribe to Add Basket Observable:
    this.basketItemAddedSubscription = this.basketEvents.addItemToBasket$.subscribe(
      item => {
        this.service.addItemToBasket(item).subscribe(res => {
          this.service.getBasket().subscribe(basket => {
            if (basket)
              this.badge = basket.basketItems.length;
          });
        });
      });

    // Subscribe to Drop Basket Observable: 
    this.basketDroppedSubscription = this.service.basketDroped$.subscribe(res => {
      this.badge = 0;
    });

    // Subscribe to login and logout observable
    this.authSubscription = this.authService.authNavStatus$.subscribe(res => {
      this.service.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.basketItems.length;
      });
    });

    // Init:
    if (this.configurationService.isReady) {
      this.service.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.basketItems.length;
      });
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.service.getBasket().subscribe(basket => {
          if (basket != null)
            this.badge = basket.basketItems.length;
        });
      });
    }
  }
}
