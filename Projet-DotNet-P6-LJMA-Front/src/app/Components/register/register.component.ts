import { Component, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from "@angular/router";
import { FormsModule, NgForm } from "@angular/forms";
import { FormRegisterService } from "../../Services/form-register.service";
import { UserRegister } from "../../Models/reg.model";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule,
    RouterOutlet,
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  user: UserRegister = {};
  constructor(public service : FormRegisterService, public router: Router ) {}

  onSubmit(form: NgForm){
    this.service.postEnregistrer()
      .subscribe({
        next: res => {
          console.log(res)
          this.router.navigate(['/home']);
        },
        error: err =>{console.log(err)}
      })
  }

  isValidLogin(): boolean{
    const valideurUtilisateur : RegExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
    return valideurUtilisateur.test(this.user.email!);
  }

  isValidPassword(): boolean{
    const valideurMotDePasse  : RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[\w!@#$%^&*(),.?":{}|<>]{12,}$/gm;
    return valideurMotDePasse.test(this.user.motDePasse!);
  }

  ngOnInit() {}
}
