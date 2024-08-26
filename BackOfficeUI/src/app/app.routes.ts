import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { GeneralComponent } from './pages/general/general.component';
import { UtilisateurComponent } from './pages/utilisateur/utilisateur.component';
import { RandonneeComponent } from './pages/randonnee/randonnee.component';
import { DetailsSessionComponent } from './pages/details-session/details-session.component';

export const routes: Routes = [
    { path: 'login', 
        loadComponent: () => import('./auth/login/login.component').then(m=>m.LoginComponent)
    },
    { path: 'general', 
        loadComponent: () => import('./pages/general/general.component').then(m=>m.GeneralComponent)
    },
    { path: 'utilisateur', 
        loadComponent: () => import('./pages/utilisateur/utilisateur.component').then(m=>m.UtilisateurComponent)
    },
    { path: 'randonnee', 
        loadComponent: () => import('./pages/randonnee/randonnee.component').then(m=>m.RandonneeComponent)
    },
    { path: 'details-session/:id', component: DetailsSessionComponent },
    { path: '', redirectTo: '/general', pathMatch: 'full' } // Redirection par défaut
];
