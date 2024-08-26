import { Component, inject } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { LoginService } from '../../../auth/login/login.service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, MatSidenavModule, RouterOutlet],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  loginService = inject(LoginService);
  router = inject(Router);

  logout() {
    this.loginService.logout();
    this.router.navigate(['general'])
  }

  login(){
    this.router.navigate(['login'])
  }
}