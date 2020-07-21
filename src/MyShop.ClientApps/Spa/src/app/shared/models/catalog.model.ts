import {ICatalogItem} from './catalogItem.model';

export interface ICatalog {
    PageIndex: number;
    Items: ICatalogItem[];
    PageSize: number;
    Count: number;
}
