import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'client';

  products: Product[] = [];

  constructor() {}

  
}
