import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../../models/auth.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit
{ 
  user:UserCredentials = {};

  onSubmit(): void {
    if(this.isValidLogin() && this.isValidPassword()){
      alert("user : "+this.user.login)
      //appel api
      //redirection Routerlink
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