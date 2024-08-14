import { Component } from '@angular/core';
import {RouterLink, RouterModule} from "@angular/router";
import {LoginComponent} from "../login/login.component";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterLink,
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  protected readonly LoginComponent = LoginComponent;
}
