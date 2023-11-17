import { Basket } from './../shared/models/basket';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUl= environment.apiUrl
  private basketSource= new BehaviorSubject<Basket | null>(null);
  basketSource$ = this.basketSource.asObservable();


  constructor(private http: HttpClient) { }

  getBasket(id: string){
    return this.http.get<Basket>(this.baseUl+'basket?id'+ id).subscribe({
      next: basket=>this.basketSource.next(basket)
    })
  }

  setBasket(basket: Basket){
    return this.http.post<Basket>(this.baseUl+ 'basket', basket).subscribe({
      next: basket=> this.basketSource.next(basket);
    })
  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }


}
