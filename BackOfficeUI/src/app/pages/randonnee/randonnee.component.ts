import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from '../../shared/components/sidebar/sidebar.component';
import { Randonnee } from '../../models/randonnee.model';
import { Theme } from '../../models/theme.model';
import { FormsModule } from '@angular/forms';
import { CommonModule} from '@angular/common';

import { RandonneeService } from '../../services/randonnee.service';
import { ThemeService } from '../../services/theme.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-randonnee',
  standalone: true,
  imports: [SidebarComponent, FormsModule, CommonModule],
  templateUrl: './randonnee.component.html',
  styleUrl: './randonnee.component.css'
})
export class RandonneeComponent implements OnInit {
  displayType: 'randonnees' | 'themes' = 'randonnees';

  RandoFilter: string = '';
  utilisateursRandoFiltre: Randonnee[] = [];


  randonnees: Randonnee[] = [];
  selectedRandonnee: Randonnee | null = null;
  isEditRandoModalOpen: boolean = false;

  isAddRandoModalOpen: boolean = false;
  newRandonnee: Randonnee = {
    desc: '',
    image: '',
    lieu: '',
    limite_participant: 0,
    nb_jour: 0,
    nb_nuit: 0,
    prix: 0
  };

  /* Themes */
  themeFilter: string = '';
  utilisateursThemeFiltre: Theme[] = [];

  themes: Theme[] = [];

  selectedTheme: Theme | null = null;
  isEditThemeModalOpen: boolean = false;

  isAddThemeModalOpen: boolean = false;
  newTheme: Theme = {
    nom: ''
  };


  constructor(
    private randonneeService: RandonneeService,
    private themeService: ThemeService
  ) {}

  ngOnInit(): void {
    this.fetchRandonees();
    this.fetchThemes();
  }

  // Récupération des randonnee dans la BDD
  fetchRandonees(): void {
    const fetchObservable: Observable<Randonnee[]> = this.randonneeService.getRandonnees();

    fetchObservable.subscribe({
      next: (data) => {
        this.randonnees = data;
        this.applyRandoFilter();
        console.log(this.randonnees); // Pour vérifier les données reçues
      },
      error: (error) => {
        console.error('Erreur lors de la récupération des randonnées', error);
      }
    });
  }

  /* Section Ajout de randonnee */

  openAddRandoModal(): void {
    this.isAddRandoModalOpen = true;
  }

  closeAddRandoModal(): void {
    this.isAddRandoModalOpen = false;
    this.resetNewRandonnee();
  }

  resetNewRandonnee(): void {
    this.newRandonnee = {
      desc: '',
      image: '',
      lieu: '',
      limite_participant: 0,
      nb_jour: 0,
      nb_nuit: 0,
      prix: 0
    };
  }

  addRandonnee(): void {
    this.randonneeService.addRandonnee(this.newRandonnee).subscribe({
      next: (createdRandonnee) => {
        // Ajouter la nouvelle randonnée à la liste locale
        this.randonnees.push(createdRandonnee);
        this.closeAddRandoModal(); // Fermer la modale après l'ajout
        this.fetchRandonees();
      },
      error: (error) => {
        console.error('Erreur lors de l\'ajout de la randonnée', error);
      }
    });
  }

  /* Fin Section Ajout de randonnee */


  /* Section Edit de randonnee */

  openEditRandoModal(randonnee: Randonnee): void {
    this.selectedRandonnee = { ...randonnee }; // Clone les données pour éviter les modifications directes
    this.isEditRandoModalOpen = true;
  }

  closeEditRandoModal(): void {
    this.isEditRandoModalOpen = false;
    this.selectedRandonnee = null;
  }

  saveRandoChanges(): void {
    if (!this.selectedRandonnee) {
      console.error('Aucune randonnée sélectionnée');
      return;
    }
  
    const originalRandonnee = this.randonnees.find(r => r.id === this.selectedRandonnee!.id);
    if (!originalRandonnee) {
      console.error('Randonnée originale non trouvée');
      return;
    }
  
    // Conserver les anciennes valeurs si les champs sont null ou undefined
    originalRandonnee.desc = this.selectedRandonnee.desc ?? originalRandonnee.desc;
    originalRandonnee.lieu = this.selectedRandonnee.lieu ?? originalRandonnee.lieu;
    originalRandonnee.limite_participant = this.selectedRandonnee.limite_participant ?? originalRandonnee.limite_participant;
    originalRandonnee.nb_jour = this.selectedRandonnee.nb_jour ?? originalRandonnee.nb_jour;
    originalRandonnee.nb_nuit = this.selectedRandonnee.nb_nuit ?? originalRandonnee.nb_nuit;
    originalRandonnee.prix = this.selectedRandonnee.prix ?? originalRandonnee.prix;
  
    // Envoyer les données mises à jour à l'API
    this.randonneeService.updateRandonnee(originalRandonnee).subscribe({
      next: () => {
        // Mettre à jour la liste locale avec les données mises à jour
        const index = this.randonnees.findIndex(r => r.id === originalRandonnee.id);
        if (index !== -1) {
          this.randonnees[index] = { ...originalRandonnee }; // Copier les données mises à jour
        }
        this.closeEditRandoModal(); // Fermer la modale après la mise à jour
        this.applyRandoFilter();
      },
      error: error => {
        console.error('Erreur lors de la mise à jour de la randonnée', error);
      },
      complete: () => {
        console.log('Mise à jour de la randonnée terminée');
      }
    });
  }

  /* Fin Section Edit de randonnee */

  // Suppression d'un randonnee

  deleteRandonnee(id: string): void {
    const deleteObservable = this.randonneeService.deleteRandonnee(id);

    deleteObservable.subscribe({
      next: () => {
        // Supprimer la randonnée de la liste locale
        this.randonnees = this.randonnees.filter(r => r.id !== id);
        this.applyRandoFilter();
        console.log(`Randonnée avec l'id ${id} supprimée.`);
      },
      error: error => {
        console.error('Erreur lors de la suppression de la randonnée', error);
      }
    });
  }

  // Filtre des randonnees

  applyRandoFilter(): void {
    this.utilisateursRandoFiltre = this.randonnees.filter(randonnee =>
      (randonnee.desc+" "+randonnee.lieu+" "+randonnee.desc).toLowerCase().includes(this.RandoFilter.toLowerCase())
    );
  }

  /* Methodes pour les Themes */

    // Récupération des theme dans la BDD
    fetchThemes(): void {
      const fetchObservable: Observable<Theme[]> = this.themeService.getThemes();
  
      fetchObservable.subscribe({
        next: (data) => {
          this.themes = data;
          this.applyThemeFilter(); 
          console.log(this.themes);
        },
        error: (error) => {
          console.error('Erreur lors de la récupération des thèmes', error);
        }
      });
    }

    /* Section Ajout de theme */

    openAddThemeModal(): void {
      this.isAddThemeModalOpen = true;
    }

    closeAddThemeModal(): void {
      this.isAddThemeModalOpen = false;
      this.resetNewTheme();
    }

    resetNewTheme(): void {
      this.newTheme = {
          nom: ''
      };
    }

    addTheme(): void {
      this.themeService.addTheme(this.newTheme).subscribe({
        next: (createdTheme) => {
          // Ajouter la nouvelle randonnée à la liste locale
          this.themes.push(createdTheme);
          this.closeAddThemeModal(); // Fermer la modale après l'ajout
          this.fetchThemes();
        },
        error: (error) => {
          console.error('Erreur lors de l\'ajout du theme', error);
        }
      });
    }

    /* Fin Section Ajout de theme */

      /* Section Edit de theme */

  openEditThemeModal(theme: Theme): void {
    this.selectedTheme = { ...theme }; // Clone les données pour éviter les modifications directes
    this.isEditThemeModalOpen = true;
  }

  closeEditThemeModal(): void {
    this.isEditThemeModalOpen = false;
    this.selectedTheme = null;
  }

  saveThemeChanges(): void {
    if (!this.selectedTheme) {
      console.error('Aucune theme sélectionnée');
      return;
    }
  
    const originalTheme = this.themes.find(r => r.id === this.selectedTheme!.id);
    if (!originalTheme) {
      console.error('Theme originale non trouvée');
      return;
    }
  
    // Conserver les anciennes valeurs si les champs sont null ou undefined
    originalTheme.nom = this.selectedTheme.nom ?? originalTheme.nom;

    // Envoyer les données mises à jour à l'API
    this.themeService.updateTheme(originalTheme).subscribe({
      next: () => {
        // Mettre à jour la liste locale avec les données mises à jour
        const index = this.themes.findIndex(r => r.id === originalTheme.id);
        if (index !== -1) {
          this.themes[index] = { ...originalTheme }; // Copier les données mises à jour
        }
        this.closeEditThemeModal(); // Fermer la modale après la mise à jour
        this.applyThemeFilter();
      },
      error: error => {
        console.error('Erreur lors de la mise à jour de la theme', error);
      },
      complete: () => {
        console.log('Mise à jour de la theme terminée');
      }
    });
  }

  /* Fin Section Edit de theme */

    // Suppression d'un theme

  deleteTheme(id: string): void {
    const deleteObservable = this.themeService.deleteTheme(id);

    deleteObservable.subscribe({
      next: () => {
        // Supprimer la randonnée de la liste locale
        this.themes = this.themes.filter(r => r.id !== id);
        this.applyThemeFilter();
        console.log(`Theme avec l'id ${id} supprimée.`);
      },
      error: error => {
        console.error('Erreur lors de la suppression du Theme', error);
      }
    });
  }

  // Filtre des Themes

  applyThemeFilter(): void {
    this.utilisateursThemeFiltre = this.themes.filter(theme =>
      theme.nom.toLowerCase().includes(this.themeFilter.toLowerCase())
    );
  }

}