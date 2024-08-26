// src/app/details-session/details-session.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionService } from '../../services/session.service';
import { UtilisateurService } from '../utilisateur/utilisateur.service';
import { ReserverService } from '../../services/reserver.service';
import { forkJoin, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Reserver } from '../../models/reserver.model';

@Component({
  selector: 'app-details-session',
  templateUrl: './details-session.component.html',
  styleUrls: ['./details-session.component.css']
})
export class DetailsSessionComponent implements OnInit {
  sessionId: string | null = '';
  session: any;
  reservations: Reserver[] = [];
  users: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private sessionService: SessionService,
    private userService: UtilisateurService,
    private reserverService: ReserverService
  ) { }

  ngOnInit(): void {
    this.sessionId = this.route.snapshot.paramMap.get('id');
    if (this.sessionId) {
      this.loadSessionDetails();
    } else {
      console.error('ID de session manquant');
      this.router.navigate(['/sessions']);
    }
  }

  loadSessionDetails(): void {
    if (!this.sessionId) return;

    this.sessionService.getSessionById(this.sessionId).pipe(
      catchError(error => {
        console.error('Erreur lors du chargement des détails de la session', error);
        return of(null);
      })
    ).subscribe(session => {
      if (session) {
        this.session = session;
        this.loadAllReservations();
      }
    });
  }

  // Récupération de l'ensemble des réservations
  loadAllReservations(): void {
    this.reserverService.getAllReservations().subscribe(reservations => {
      // console.log('Toutes les réservations:', reservations);
      // Filtrage des réservations pour ne garder que celles lié a la session séléctionnée
      this.reservations = reservations.filter(r => r.sessionId === this.sessionId);
      // console.log('Réservations filtrées:', this.reservations);
      this.loadUsersForReservations();
    });
  }

// Récupération des utilisateurs liés aux réservations
loadUsersForReservations(): void {
  if (this.reservations.length > 0) {
    const userIds = this.reservations.map(r => r.utilisateurId);
    forkJoin(userIds.map(id => this.userService.getUserById(id))).subscribe(users => {
      this.users = users.map((user, index) => ({
        ...user,
        nb_participant: this.reservations[index]?.nb_participant
      }));
      // console.log('Utilisateurs chargés:', this.users);
    });
  } else {
    console.log('Aucune réservation trouvée pour cette session');
  }
}
}