import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from '../../shared/components/sidebar/sidebar.component';
import { Utilisateur } from '../../models/utilisateur.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-utilisateur',
  standalone: true,
  imports: [SidebarComponent, FormsModule],
  templateUrl: './utilisateur.component.html',
  styleUrls: ['./utilisateur.component.css']  
})
export class UtilisateurComponent implements OnInit {
  userFilter: string = '';
  utilisateurs!: Utilisateur[];
  utilisateursFiltre: Utilisateur[] = [];

  ngOnInit(): void {
    this.utilisateurs = [
      {
        id: 1,
        nom: 'Jean',
        prenom: 'Marie',
        tel: '0679393927',
        mail: 'mail@exemple.com',
        role: 'Utilisateur'
      },
      {
        id: 2,
        nom: 'Claire',
        prenom: 'Dupont',
        tel: '0673342927',
        mail: 'mail@exemple.com',
        role: 'Utilisateur'
      },
      {
        id: 3,
        nom: 'Damien',
        prenom: 'Craine',
        tel: '0638382728',
        mail: 'mail@exemple.com',
        role: 'Admin'
      },
    ];

    this.applyFilter();
  }

  // Filtre des utilisateur, pouvant chercher pas nom, prenom ou les deux dans n'importe quel ordre
  applyFilter(): void {
    this.utilisateursFiltre = this.utilisateurs.filter(utilisateur =>
      (utilisateur.nom+" "+utilisateur.prenom+" "+utilisateur.nom).toLowerCase().includes(this.userFilter.toLowerCase())
    );
  }
}