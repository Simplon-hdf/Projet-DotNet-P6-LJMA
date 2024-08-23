import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import {LoginButtonComponent} from "../login-button/login-button.component";
import {RegisterButtonComponent} from "../register-button/register-button.component";

@Component({
  selector: 'app-burger-menu',
  standalone: true,
  imports: [
    RouterLink,
    LoginButtonComponent,
    RegisterButtonComponent
  ],
  templateUrl: './burger-menu.component.html',
  styleUrl: './burger-menu.component.css'
})
export class BurgerMenuComponent {

}
