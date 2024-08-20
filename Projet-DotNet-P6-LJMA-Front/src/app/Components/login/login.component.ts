import { Component, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from "@angular/router";
import { FormsModule, NgForm } from "@angular/forms";
import { FormLoginService } from "../../Services/form-login.service";
import { UserCredentials } from "../../Models/auth.model";
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule,
    RouterOutlet,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent implements OnInit {
  user: UserCredentials = {};
  constructor(public service: FormLoginService, public router : Router) {}

  onSubmit(form: NgForm) {
    this.service.getLogin(this.user.email!, this.user.motDePasse!)
      .subscribe({
        next: (res: any) => {
          console.log(res);
          // Gérer la réponse de connexion réussie ici
          this.router.navigate(['/home']);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          // Gérer les erreurs de connexion ici
        }
      });
  }

  isValidLogin(): boolean {
    const valideurUtilisateur: RegExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
    return valideurUtilisateur.test(this.user.email!);
  }

  ngOnInit() {}
}
