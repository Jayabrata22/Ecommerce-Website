import { Component, Input } from '@angular/core';
import { Product } from '../../shared/models/product';
import { MatCard, MatCardActions, MatCardContent } from '@angular/material/card';
import { CurrencyPipe } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-product-items',
  imports: [MatCard,MatCardContent, CurrencyPipe,
    MatCardActions,MatButton,MatIcon],
  templateUrl: './product-items.component.html',
  styleUrls: ['./product-items.component.scss']
})
export class ProductItemsComponent {
  @Input() product?: Product;
}
