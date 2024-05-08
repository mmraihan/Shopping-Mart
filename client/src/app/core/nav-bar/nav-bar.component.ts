import { BasketService } from 'src/app/basket/basket.service';
import { AccountService } from './../../account/account.service';
import { Component } from '@angular/core';
import { BasketItem } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {

  constructor(public accountService: AccountService, public basketService: BasketService) { }

  getCount(items: BasketItem[]){
    return items.reduce((sum, item)=>sum+item.quantity,0)
  }

}
