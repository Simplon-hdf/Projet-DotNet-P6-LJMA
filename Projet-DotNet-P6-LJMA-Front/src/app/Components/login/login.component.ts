import {Component, OnInit} from '@angular/core';
import {RouterLink, Router} from "@angular/router";
import {FormsModule} from "@angular/forms";
import {UserCredentials} from "../../Models/auth.model";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  user:UserCredentials = {};
  constructor(private router: Router) {}

  onSubmit(): void {
    if (this.isValidLogin() && this.isValidPassword()) {
      console.log("User : " + this.user.login); // Remplacé alert par console.log pour le débogage

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

  isValidLogin(): boolean{
    const valideurUtilisateur : RegExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
    return valideurUtilisateur.test(this.user.login!);
  }

  isValidPassword(): boolean{
    const valideurMotDePasse  : RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[\w!@#$%^&*(),.?":{}|<>]{12,}$/gm;
    return valideurMotDePasse.test(this.user.motDePasse!);
  }

  ngOnInit(): void {}
}
