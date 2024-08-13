import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, MatSidenavModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  logout() {
    // Ajoutez ici la logique de déconnexion, par exemple :
    console.log('Déconnexion');
    // Redirigez vers la page de connexion ou la page d'accueil
    // window.location.href = '/login'; // Exemple de redirection
  }
}