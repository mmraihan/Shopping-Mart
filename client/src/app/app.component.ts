import { Component } from '@angular/core';
import { Product } from './shared/models/product';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'client';

  products: Product[] = [];

  constructor(private accountService: AccountService, private basketService: BasketService) {}
  ngOnInit() {
    this.loadCurrentUser();
    const basketId = localStorage.getItem('basket_Id')
    if(basketId) this.basketService.getBasket(basketId);
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    if (token) this.accountService.loadCurrentUser(token).subscribe();
  }
}
