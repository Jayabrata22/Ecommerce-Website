import { HttpClient } from '@angular/common/http';
import {inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseurl= 'https://localhost:7292/api/'
    private http = inject(HttpClient);
    types: string[]=[];
    brands: string[]=[];
  getProducts(){
    return this.http.get<Pagination<Product>>(this.baseurl + 'product?pageSize=20')
  }
  getBrands(){
    if(this.brands.length>0) return this.brands;
    return this.http.get<string[]>(this.baseurl + 'product/brands').subscribe({
      next: response=> this.brands = response
    })
  }

  getTypes(){
    if(this.types.length>0) return this.types;
    return this.http.get<string[]>(this.baseurl + 'product/types').subscribe({
      next: response=> this.types = response
    })
  }
}
