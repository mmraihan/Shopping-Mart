import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: Product[]=[];
  brands: Brand[]=[];
  types: Type[]=[];
  brandIdSelected=0;
  typeIdSelected=0;


  constructor(private shopService: ShopService){

  }


  ngOnInit(): void { 

    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(){
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe({
      next: response=>this.products=response.data,
      error: error=>console.log(error)
    })
  }

  getBrands(){
    this.shopService.getBrands().subscribe({
      next: res=>this.brands=[{id: 0, name: 'All'}, ...res],
      error: error=>console.log(error)

    })
  }

  getTypes(){
    this.shopService.getTypes().subscribe({
      next: res=>this.types=[{id: 0, name: 'All'}, ...res],
      error: error=>console.log(error)
    })
  }

  onBrandSelected(brandId: number){
    this.brandIdSelected=brandId;
    this.getProducts()
  }

  onTypeSelected(typeId: number){
    this.typeIdSelected=typeId;
    this.getProducts()
  }


}
