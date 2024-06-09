import { Basket, BasketItem, BasketTotals } from './../shared/models/basket';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUl= environment.apiUrl
  private basketSource= new BehaviorSubject<Basket | null>(null);
  basketSource$ = this.basketSource.asObservable();

  private basketTotalSource = new BehaviorSubject<BasketTotals | null>(null);
  basketTotalSource$ = this.basketTotalSource.asObservable();


  constructor(private http: HttpClient) { }

  getBasket(id: string){
    return this.http.get<Basket>(this.baseUl+'basket?id'+ id).subscribe({
      next: basket=>this.basketSource.next(basket)
    })
  }

  setBasket(basket: Basket){
    return this.http.post<Basket>(this.baseUl+ 'basket', basket).subscribe({
      next: basket=> this.basketSource.next(basket)
    })
  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }

  addItemToBasket(item: Product, quantity=1){
    const itemToAdd=this.mapProductItemToBasketItem(item);
    const basket= this.getCurrentBasketValue()?? this.createBasket();
    basket.items=this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);


  }
  createBasket(): Basket  {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapProductItemToBasketItem(item: Product): BasketItem{
    return{
      id:item.id,
      productName: item.name,
      price: item.price,
      quantity:0,
      pictureurl:item.pictureUrl,
      brand:item.productBrand,
      type:item.productBrand     
    }
  }

  private  addOrUpdateItem(items: BasketItem[], itemToAdd: BasketItem, 
    quantity: number) : BasketItem[]  {
    const item= items.find(x=>x.id===itemToAdd.id);
    if(item)item.quantity+=quantity;
    else{
      itemToAdd.quantity=quantity;
      items.push(itemToAdd);
    }
    return items;
  }


}
