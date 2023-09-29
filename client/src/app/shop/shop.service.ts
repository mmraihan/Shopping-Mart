import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http: HttpClient) { 
  }

  baseUrl: string= 'https://localhost:7024/api/'


  getProducts(brandId?: number, productId?:number){
    let params = new HttpParams();

    if(brandId) params= params.append('brandId', brandId)
    if(productId) params = params.append('productId', productId)


    return this.http.get<Pagination<Product[]>>(this.baseUrl+ 'products', {params});
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl+'products/brands')
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl+'products/types')
  }


}
