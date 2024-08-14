import { Component, OnInit } from '@angular/core';
import {RouterLink, Router} from "@angular/router";
import {FormsModule, MaxLengthValidator} from "@angular/forms";
import {LoginComponent} from "../login/login.component";
import { UserRegister } from "../../Models/reg.model";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule,
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  user:UserRegister = {};

  constructor(private router: Router) {}

  onSubmit(): void {
    if (this.isValidMail() && this.isValidPassword() && this.isValidNumber()) {
      console.log("User : " + this.user.email); // Remplacé alert par console.log pour le débogage

      // Ici, vous devriez normalement faire un appel API pour l'authentification
      // Pour l'instant, nous allons simplement simuler une connexion réussie

      // Redirection
      this.router.navigate(["/home"]);
    } else {
      // Ajout d'un message d'erreur si la validation échoue
      console.error("Login ou mot de passe invalide");
      // Vous pouvez afficher un message à l'utilisateur ici
    }
  }

  isValidMail(): boolean{
    const valideurMail : RegExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
    return valideurMail.test(this.user.email!);
  }

  isValidNumber(): boolean {
    if (!this.user.tel) {
      return false; // Le numéro est vide ou non défini
    }

    // Expression régulière pour les numéros de téléphone français
    const phonePattern = /^(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}$/;

    return phonePattern.test(this.user.tel);
  }

  isValidPassword(): boolean{
    const valideurMotDePasse  : RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[\w!@#$%^&*(),.?":{}|<>]{12,}$/gm;
    return valideurMotDePasse.test(this.user.motDePasse!);
  }

  ngOnInit(): void {}
}
