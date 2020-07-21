import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ServicesRoutingModule } from './services-routing.module';
import { BasketComponent } from './basket/basket.component';
import { CatalogComponent } from './catalog/catalog.component';
import { OrderComponent } from './order/order.component';
import { CatalogService } from './catalog/catalog.service';
import { CommonModule } from '@angular/common';
import { BasketStatusComponent } from './basket/basket-status/basket-status.component';
import { BasketService } from './basket/basket.service';
import { BasketWrapperService } from '../shared/services/basket.wrapper.service';

@NgModule({
  declarations: [
    BasketComponent,
    CatalogComponent,
    OrderComponent,
    BasketStatusComponent
  ],
  imports: [
    ServicesRoutingModule,
    CommonModule
  ],
  providers: [
    CatalogService,
    BasketService,
    BasketWrapperService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ServicesModule { }
