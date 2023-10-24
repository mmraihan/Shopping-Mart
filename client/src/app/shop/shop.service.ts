import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http: HttpClient) { 
  }

  baseUrl: string= 'https://localhost:7024/api/'


  getProducts(shopPrams: ShopParams){
    let params = new HttpParams();

    if(shopPrams.brandId>0) params= params.append('brandId', shopPrams.brandId);
    if(shopPrams.productId>0) params = params.append('productId', shopPrams.productId);
    params=params.append('sort',shopPrams.sort);
    params=params.append('pageIndex', shopPrams.pageNumber);
    params=params.append('pageSize', shopPrams.pageSize);
   if(shopPrams.search) params=params.append('search', shopPrams.search);


    return this.http.get<Pagination<Product[]>>(this.baseUrl+ 'products', {params});
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl+'products/brands')
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl+'products/types')
  }


}
