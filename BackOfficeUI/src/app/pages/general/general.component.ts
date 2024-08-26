import { Component, inject } from '@angular/core';
import { SidebarComponent } from "../../shared/components/sidebar/sidebar.component";
import { LoginService } from '../../auth/login/login.service';

@Component({
  selector: 'app-general',
  standalone: true,
  imports: [SidebarComponent],
  templateUrl: './general.component.html',
  styleUrl: './general.component.css'
})
export class GeneralComponent {
 	loginService = inject(LoginService);
  randonnees = [
    {
      id: 1,
      nom: 'Ardenne',
      participant: 7,
      nuit: 3,
      lieu: 'Foret',
      prix: 134
    },
    {
      id: 2,
      nom: 'Alpes',
      participant: 7,
      nuit: 3,
      lieu: 'Montagne',
      prix: 230
    },
    {
      id: 3,
      nom: 'Pyrenees',
      participant: 7,
      nuit: 3,
      lieu: 'Montagne',
      prix: 12
    },
  ];

  utilisateurs = [
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
}
