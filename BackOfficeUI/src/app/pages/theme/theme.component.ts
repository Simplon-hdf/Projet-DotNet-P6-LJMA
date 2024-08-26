import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from '../../shared/components/sidebar/sidebar.component';
import { FormsModule } from '@angular/forms';
import { CommonModule} from '@angular/common';

import { Theme } from '../../models/theme.model';
import { ThemeService } from '../../services/theme.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-theme',
  standalone: true,
  imports: [SidebarComponent, FormsModule, CommonModule],
  templateUrl: './theme.component.html',
  styleUrl: './theme.component.css'
})
export class ThemeComponent {

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
    private themeService: ThemeService
  ) {}

  ngOnInit(): void {
    this.fetchThemes();
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
