import { HttpClient } from '@angular/common/http';
import {inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseurl= 'https://localhost:7292/api/'
    private http = inject(HttpClient)
  getProducts(){
    return this.http.get<Pagination<Product>>(this.baseurl + 'product?pageSize=20')
  }
}
