import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'client';

  products: Product[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:7024/api/products?pageSize=50').subscribe({
      next: response => this.products = response.data, 
      error: error => console.log(error),
      complete: () => {
        console.log('request completed');
        console.log('extra statment');
      }
    })
  }
}
