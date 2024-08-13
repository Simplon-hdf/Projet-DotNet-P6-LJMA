import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'general', loadComponent: () => import('./pages/general/general.component').then(m => m.GeneralComponent) },
  { path: 'utilisateur', loadComponent: () => import('./pages/utilisateur/utilisateur.component').then(m => m.UtilisateurComponent) },
  { path: 'randonnee', loadComponent: () => import('./pages/randonnee/randonnee.component').then(m => m.RandonneeComponent) },
  { path: '', redirectTo: '/general', pathMatch: 'full' } // Redirection par défaut
];