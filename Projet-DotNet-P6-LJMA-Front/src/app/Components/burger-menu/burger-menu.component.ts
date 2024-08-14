import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-burger-menu',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './burger-menu.component.html',
  styleUrl: './burger-menu.component.css'
})
export class BurgerMenuComponent {

}
