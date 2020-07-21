import { Component, OnInit } from '@angular/core';
import { CatalogService } from './catalog.service';
import { IPager } from 'src/app/shared/models/pager.model';
import { ConfigService } from 'src/app/shared/services/config.service';
import { ICatalog } from 'src/app/shared/models/catalog.model';
import { ICatalogItem } from 'src/app/shared/models/catalogItem.model';
import { BasketWrapperService } from 'src/app/shared/services/basket.wrapper.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.sass']
})
export class CatalogComponent implements OnInit {
  paginationInfo: IPager;
  brandSelected: number;
  typeSelected: number;
  catalogs: any;
  constructor(private basketService:BasketWrapperService, private catalogService: CatalogService, private configService: ConfigService) {


  }

  ngOnInit(): void {
    if (this.configService.isReady) {
      this.loadData();
    } else {
      this.configService.settingsLoaded$.subscribe(x => {
        this.loadData();
      });
    }
  }

  loadData() {
    // this.getBrands();
    this.getCatalogs(10, 0);
    //this.getTypes();
  }

  getCatalogs(pageSize: number, pageIndex: number, brand?: number, type?: number) {
    this.catalogService.getCatalog(pageSize, pageIndex, brand, type)
      .subscribe((res: any) => {
        this.catalogs = res.items;
      })
  }



  addToCart(item: ICatalogItem) {
    this.basketService.addItemToBasket(item);
  }

}
