import { Component, inject } from '@angular/core';
import {RouterLink} from "@angular/router";
import {LoginButtonComponent} from "../login-button/login-button.component";
import {RegisterButtonComponent} from "../register-button/register-button.component";
import { LoginService } from '../../Services/login.service';
import { LogoutButtonComponent } from "../logout-button/logout-button.component";

@Component({
  selector: 'app-burger-menu',
  standalone: true,
  imports: [
    RouterLink,
    LoginButtonComponent,
    RegisterButtonComponent,
    LogoutButtonComponent
],
  templateUrl: './burger-menu.component.html',
  styleUrl: './burger-menu.component.css'
})
export class BurgerMenuComponent {
  loginService = inject(LoginService);
}
