import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product';
import { ShopService } from '../../Core/services/shop.service';
import { MatCardModule } from '@angular/material/card';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ProductItemsComponent } from "../product-items/product-items.component";


@Component({
  selector: 'app-shop',
  imports: [MatCardModule, ProductItemsComponent],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  private service = inject(ShopService);

  products: Product[] =[];
title: any;

  ngOnInit(): void {
    this.service.getProducts().subscribe({
      next: response=> this.products = response.data,
      error: error=>console.log(error),
      // complete: ()=> console.log('complete')
      // // next: next => console.log(next),
      // // error: erro=> console.log(erro),
      // // complete: ()=> console.log("Complete")
      
    })
  }

}
