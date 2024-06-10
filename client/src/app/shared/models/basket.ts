import * as cuid from 'cuid';
import { Product } from './product';
export interface BasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureurl: string;
    brand: string;
    type: string;
}

export interface Basket {
    id: string;
    items: BasketItem[];
}

export class Basket implements Basket {  
    id = cuid();
    items: BasketItem[] = [];
}
export interface BasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
}

