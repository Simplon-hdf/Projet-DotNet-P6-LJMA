import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from '../../shared/components/sidebar/sidebar.component';
import { Randonnee } from '../../models/randonnee.model';
import { FormsModule } from '@angular/forms';
import { CommonModule} from '@angular/common';

import { RandonneeService } from '../../services/randonnee.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-randonnee',
  standalone: true,
  imports: [SidebarComponent, FormsModule, CommonModule],
  templateUrl: './randonnee.component.html',
  styleUrl: './randonnee.component.css'
})
export class RandonneeComponent implements OnInit {
  userFilter: string = '';
  utilisateursFiltre: Randonnee[] = [];


  randonnees: Randonnee[] = [];
  selectedRandonnee: Randonnee | null = null;
  isEditRandoModalOpen: boolean = false;

  isAddModalOpen: boolean = false;
  newRandonnee: Randonnee = {
    desc: '',
    image: '',
    lieu: '',
    limite_participant: 0,
    nb_jour: 0,
    nb_nuit: 0,
    prix: 0
  };

  constructor(private randonneeService: RandonneeService) {}

  ngOnInit(): void {
    this.fetchRandonees();
  }

  // Récupération des randonnee dans la BDD
  fetchRandonees(): void {
    const fetchObservable: Observable<Randonnee[]> = this.randonneeService.getRandonees();

    fetchObservable.subscribe({
      next: (data) => {
        this.randonnees = data;
        this.utilisateursFiltre = data;
        this.applyFilter();
        console.log(this.randonnees); // Pour vérifier les données reçues
      },
      error: (error) => {
        console.error('Erreur lors de la récupération des randonnées', error);
      }
    });
  }

  /* Section Ajout de randonnee */

  openAddModal(): void {
    this.isAddModalOpen = true;
  }

  closeAddModal(): void {
    this.isAddModalOpen = false;
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
        this.closeAddModal(); // Fermer la modale après l'ajout
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
        this.applyFilter();
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
        this.applyFilter();
        console.log(`Randonnée avec l'id ${id} supprimée.`);
      },
      error: error => {
        console.error('Erreur lors de la suppression de la randonnée', error);
      }
    });
  }


  applyFilter(): void {
    this.utilisateursFiltre = this.randonnees.filter(randonnee =>
      (randonnee.desc+" "+randonnee.lieu+" "+randonnee.desc).toLowerCase().includes(this.userFilter.toLowerCase())
    );
  }
}