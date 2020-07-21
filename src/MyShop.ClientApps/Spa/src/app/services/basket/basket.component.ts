import { Component, OnInit } from '@angular/core';
import { IBasket } from 'src/app/shared/models/basket.model';
import { BasketService } from './basket.service';
import { Router } from '@angular/router';
import { IBasketItem } from 'src/app/shared/models/basketItem.model';
import { Observable } from 'rxjs';
import { BasketWrapperService } from 'src/app/shared/services/basket.wrapper.service';

@Component({
    selector: 'app-basket',
    templateUrl: './basket.component.html',
    styleUrls: ['./basket.component.sass']
})
export class BasketComponent implements OnInit {
    basket: IBasket;
    totalPrice: number = 0;

    constructor(private basketwrapper: BasketWrapperService, private service: BasketService, private router: Router) { }

    ngOnInit() {
        this.service.getBasket().subscribe(basket => {
            this.basket = basket;
            this.calculateTotalPrice();
        });
    }

    itemQuantityChanged(item: IBasketItem) {
        this.calculateTotalPrice();
        this.service.setBasket(this.basket).subscribe(x => console.log('basket updated: ' + x));
    }

    update(event: any): Observable<boolean> {
        let setBasketObservable = this.service.setBasket(this.basket);
        setBasketObservable
            .subscribe(
                x => {
                    // this.errorMessages = [];
                    console.log('basket updated: ' + x);
                },
                errMessage => {
                    // this.errorMessages = errMessage.messages
                });
        return setBasketObservable;
    }

    checkOut(event: any) {
        this.update(event)
            .subscribe(
                x => {
                    // this.errorMessages = [];
                    this.basketwrapper.basket = this.basket;

                    let checkoutModel = {
                        Address: {
                            City: "Bhubaneswar",
                            Street: "TSHYS-67",
                            State: "Orissa",
                            Country: "India",
                            ZipCode: "678292"
                        },
                        PaymentMethod: {
                            CardNumber: "28932903233984739",
                            Cardexpiration: new Date("09/12/2020"),
                            Cardsecuritynumber: "768",
                            Cardholdername: "Ashis Mahapatra",
                            Cardtypeid: 1
                        },
                        BuyerId: this.basket.buyerId,
                        UserName: "Ashis"
                    };
                    this.service.setBasketCheckout(checkoutModel)
                        .subscribe(res => {
                            console.log(res);
                        },
                            error => {
                                console.log(error);
                            }
                        )

                    //this.router.navigate(['order']);
                });
    }

    private calculateTotalPrice() {
        this.totalPrice = 0;
        this.basket.basketItems.forEach(item => {
            this.totalPrice += (item.unitPrice * item.quantity);
        });
    }
}
