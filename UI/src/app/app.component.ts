import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  baseurl= 'https://localhost:7292/api/'
  private http = inject(HttpClient)
  title = 'Ecommerce-UI';
  products: Product[] =[];

  ngOnInit(): void {
    this.http.get<Pagination<Product>>(this.baseurl + 'Product').subscribe({
      next: Response=> this.products = Response.data,
      error: error=>console.log(error),
      complete: ()=> console.log('complete')
      
    })
  }

}
