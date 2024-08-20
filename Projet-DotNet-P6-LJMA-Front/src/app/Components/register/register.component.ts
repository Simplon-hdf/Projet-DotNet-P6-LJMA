import {Component, Injectable, OnInit} from '@angular/core';
import { RouterLink, RouterOutlet } from "@angular/router";
import { FormsModule, NgForm } from "@angular/forms";
import { FormRegisterService } from "../../Services/form-register.service";

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
  constructor(public service : FormRegisterService ) {}

  onSubmit(form: NgForm){
    this.service.postEnregistrer()
      .subscribe({
        next:res => {
          console.log(res)
        },
        error:err=>{console.log(err)}
      })
  }

  ngOnInit() {}
}
