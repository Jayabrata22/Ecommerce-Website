import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product';
import { ShopService } from '../../Core/services/shop.service';
import { MatCardModule } from '@angular/material/card';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ProductItemsComponent } from "../product-items/product-items.component";
<<<<<<< HEAD
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-shop',
  imports: [MatCardModule, ProductItemsComponent, MatButton,MatIcon],
=======


@Component({
  selector: 'app-shop',
  imports: [MatCardModule, ProductItemsComponent],
>>>>>>> 041647e98e1e18f76e0d4ec1a0fcd81cb3bb285b
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  private service = inject(ShopService);
<<<<<<< HEAD
  private dialogService = inject(MatDialog);
=======

>>>>>>> 041647e98e1e18f76e0d4ec1a0fcd81cb3bb285b
  products: Product[] =[];
title: any;

  ngOnInit(): void {
<<<<<<< HEAD
    this.initializeShop();
  }

  initializeShop(){
    this.service.getBrands();
    this.service.getTypes();
=======
>>>>>>> 041647e98e1e18f76e0d4ec1a0fcd81cb3bb285b
    this.service.getProducts().subscribe({
      next: response=> this.products = response.data,
      error: error=>console.log(error),
      // complete: ()=> console.log('complete')
      // // next: next => console.log(next),
      // // error: erro=> console.log(erro),
      // // complete: ()=> console.log("Complete")
      
    })
  }

<<<<<<< HEAD
  openFiltersDialog(){
    const dialogref = this.dialogService.open(FiltersDialogComponent,{
      minWidth: '300px'
    });
  }

=======
>>>>>>> 041647e98e1e18f76e0d4ec1a0fcd81cb3bb285b
}
