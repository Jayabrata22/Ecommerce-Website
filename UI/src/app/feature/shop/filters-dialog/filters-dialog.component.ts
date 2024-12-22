import { Component, inject } from '@angular/core';
import { ShopService } from '../../../Core/services/shop.service';
import { MatDivider } from '@angular/material/divider';
import { MatListOption, MatSelectionList } from '@angular/material/list';
@Component({
  selector: 'app-filters-dialog',
  imports: [MatDivider , MatSelectionList,MatListOption],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent {
  shopservice = inject(ShopService);
}
