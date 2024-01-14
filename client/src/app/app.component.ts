import { Component } from '@angular/core';
import { Product } from './shared/models/product';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'client';

  products: Product[] = [];

  ngOnInit() {
    this.loadCurrentUser();
  }

  constructor(private accountService: AccountService) {}

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    if (token) this.accountService.loadCurrentUser(token).subscribe();
  }
}
