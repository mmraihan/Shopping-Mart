import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http: HttpClient) { }

  baseUrl: string= 'https://localhost:7024/api/'


  getProducts(){
    return this.http.get<Pagination<Product[]>>(this.baseUrl+ 'products?pageSize=50');
  }


}
