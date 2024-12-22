import { Component } from '@angular/core';
import { MatBadge } from '@angular/material/badge';
import { MatButton } from '@angular/material/button';
import {MatIcon} from '@angular/material/icon'
import { Route, Router } from '@angular/router';
@Component({
  selector: 'app-header',
  imports: [
    MatIcon,
    MatBadge,
    MatButton
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  constructor(private router: Router) { }
navigateTo(route: string) {
this.router.navigate([`/${route}`]);
}

}
