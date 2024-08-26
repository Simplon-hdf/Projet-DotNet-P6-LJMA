import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Session } from '../../models/session.model';
import { SessionService } from '../../services/session.service';
import { FormsModule } from '@angular/forms';

import { Theme } from '../../models/theme.model';
import { ThemeService } from '../../services/theme.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-session',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.css']
})
export class SessionComponent implements OnInit {
  @Input() randonneeId?: string = '';
  sessions: Session[] = [];

  areSessionsVisible: boolean = false;

  isAddSessionModalOpen: boolean = false;
  newSession: Session = { nom: '', date_debut: new Date(), date_fin: new Date(), randonneeId: '' ,themeId: ''};

  isEditSessionModalOpen: boolean = false;
  selectedSession: Session | null = null;

  themes: Theme[] = [];

  constructor(
    private sessionService: SessionService,
    private themeService: ThemeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchSessions();
    this.fetchThemes();
  }

  toggleSessionsVisibility(): void {
    this.areSessionsVisible = !this.areSessionsVisible; // Bascule la visibilité
  }
  
  fetchSessions(): void {
    this.sessionService.getSessions().subscribe({
      next: (data) => {
        // Filtrer les sessions pour n'afficher que celles qui correspondent à la randonnée actuelle
        this.sessions = data.filter(session => session.randonneeId === this.randonneeId);
        console.log(this.sessions);
      },
      error: (error) => {
        console.error('Erreur lors de la récupération des sessions', error);
      }
    });
  }

  fetchThemes(): void {
    this.themeService.getThemes().subscribe({
      next: (data) => {
        this.themes = data;
      },
      error: (error) => {
        console.error('Erreur lors de la récupération des thèmes', error);
      }
    });
  }

      /* Section Ajout de session */

      openAddSessionModal(): void {
        this.newSession = { nom: '', date_debut: new Date(), date_fin: new Date(), randonneeId: this.randonneeId!, themeId: '' };
        this.isAddSessionModalOpen = true;
      }
  
      closeAddSessionModal(): void {
        this.isAddSessionModalOpen = false;
      }
  
      addSession(): void {
        this.sessionService.addSession(this.newSession).subscribe({
          next: (createdSession) => {
            // Ajouter la nouvelle randonnée à la liste locale
            this.sessions.push(createdSession);
            this.closeAddSessionModal(); // Fermer la modale après l'ajout
            this.fetchSessions();
          },
          error: (error) => {
            console.error('Erreur lors de l\'ajout du session', error);
          }
        });
      }
  
      /* Fin Section Ajout de session */

  /* Section Edit de session */
  editSession(session: Session): void {
    this.selectedSession = { ...session }; // Clone les données pour éviter les modifications directes
    this.isEditSessionModalOpen = true;
  }

  closeEditSessionModal(): void {
    this.isEditSessionModalOpen = false;
    this.selectedSession = null;
  }

  saveSessionChanges(): void {
    if (!this.selectedSession) {
      console.error('Aucune session sélectionnée');
      return;
    }
  
    const originalSession = this.sessions.find(r => r.id === this.selectedSession!.id);
    if (!originalSession) {
      console.error('Session originale non trouvée');
      return;
    }
  
    // Conserver les anciennes valeurs si les champs sont null ou undefined
    originalSession.nom = this.selectedSession.nom ?? originalSession.nom;
    originalSession.date_debut = this.selectedSession.date_debut ?? originalSession.date_debut;
    originalSession.date_fin = this.selectedSession.date_fin ?? originalSession.date_fin;

    // Envoyer les données mises à jour à l'API
    this.sessionService.updateSession(originalSession).subscribe({
      next: () => {
        // Mettre à jour la liste locale avec les données mises à jour
        const index = this.sessions.findIndex(r => r.id === originalSession.id);
        if (index !== -1) {
          this.sessions[index] = { ...originalSession }; // Copier les données mises à jour
        }
        this.closeEditSessionModal(); // Fermer la modale après la mise à jour
      },
      error: error => {
        console.error('Erreur lors de la mise à jour de la session', error);
      },
      complete: () => {
        console.log('Mise à jour de la session terminée');
      }
    });
  }

    /* Fin Section Edit de session */

  // Suppression d'un session

  deleteSession(id: string): void {
    const deleteObservable = this.sessionService.deleteSession(id);

    deleteObservable.subscribe({
      next: () => {
        // Supprimer la randonnée de la liste locale
        this.sessions = this.sessions.filter(r => r.id !== id);
        console.log(`Session avec l'id ${id} supprimée.`);
      },
      error: error => {
        console.error('Erreur lors de la suppression du Session', error);
      }
    });
  }

  viewSessionDetails(sessionId: string): void {
    this.router.navigate(['/details-session', sessionId]);
  }
}

