// app.routes.ts
import { Routes } from '@angular/router';
import {LoginComponent} from "./Components/login/login.component";
import { RegisterComponent } from "./Components/register/register.component";
import {HomeComponent} from "./Pages/home/home.component";
import {BurgerMenuComponent} from "./Components/burger-menu/burger-menu.component";
import {SejourComponent} from "./Components/sejour/sejour.component";
import {AboutComponent} from "./Pages/about/about.component";

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signin', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'menu', component: BurgerMenuComponent },
  { path: 'sejour', component: SejourComponent },
  { path: 'about', component: AboutComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];
