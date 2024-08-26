import { Component } from '@angular/core';
import { SidebarComponent } from './shared/components/sidebar/sidebar.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SidebarComponent, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = "BackOfficeUI";
  isSidebarOpen = false;  // true par défaut pour les grands écrans

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }
}