import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product';
import { ShopService } from '../../Core/services/shop.service';
import { MatCardModule } from '@angular/material/card';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ProductItemsComponent } from "../product-items/product-items.component";
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-shop',
  imports: [MatCardModule, ProductItemsComponent, MatButton,MatIcon],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  private service = inject(ShopService);
  private dialogService = inject(MatDialog);
  products: Product[] =[];
title: any;

  ngOnInit(): void {
    this.initializeShop();
  }

  initializeShop(){
    this.service.getBrands();
    this.service.getTypes();
    this.service.getProducts().subscribe({
      next: response=> this.products = response.data,
      error: error=>console.log(error),
      // complete: ()=> console.log('complete')
      // // next: next => console.log(next),
      // // error: erro=> console.log(erro),
      // // complete: ()=> console.log("Complete")
      
    })
  }

  openFiltersDialog(){
    const dialogref = this.dialogService.open(FiltersDialogComponent,{
      minWidth: '300px'
    });
  }

}
