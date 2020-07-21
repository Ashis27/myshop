import { IBasketItem } from './basketItem.model';

export interface IBasket {
    basketItems: IBasketItem[];
    buyerId: string;
}
