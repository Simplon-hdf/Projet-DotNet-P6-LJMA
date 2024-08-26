import {Component, inject} from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import {LoginService} from "../../Services/login.service";

@Component({
  selector: 'app-register-button',
  standalone: true,
    imports: [
        RouterLink
    ],
  templateUrl: './register-button.component.html',
  styleUrl: './register-button.component.css'
})
export class RegisterButtonComponent {
  loginService = inject(LoginService);
  router = inject(Router);

  register(){
    this.router.navigate(['signin']);
  }
}
