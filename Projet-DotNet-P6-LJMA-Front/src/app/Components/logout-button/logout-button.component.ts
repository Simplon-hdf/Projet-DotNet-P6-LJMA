import { Component, inject } from '@angular/core';
import { LoginService } from '../../Services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout-button',
  standalone: true,
  imports: [],
  templateUrl: './logout-button.component.html',
  styleUrl: './logout-button.component.css'
})
export class LogoutButtonComponent {
  loginService = inject(LoginService);
  router = inject(Router);

  logout(){
    this.loginService.logout();
    this.router.navigate(['home']);
  }
}
