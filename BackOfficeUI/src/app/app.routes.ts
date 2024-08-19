import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { GeneralComponent } from './pages/general/general.component';
import { UtilisateurComponent } from './pages/utilisateur/utilisateur.component';
import { RandonneeComponent } from './pages/randonnee/randonnee.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'general', component: GeneralComponent },
    { path: 'utilisateur', component: UtilisateurComponent},
    { path: 'randonnee', component: RandonneeComponent},
    { path: '', redirectTo: '/general', pathMatch: 'full' } // Redirection par défaut
];
