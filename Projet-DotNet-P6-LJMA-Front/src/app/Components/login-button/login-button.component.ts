import {Component, inject, Injectable, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import { LoginService } from '../../Services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-button',
  standalone: true,
  imports: [
    RouterLink,
  ],
  templateUrl: './login-button.component.html',
  styleUrl: './login-button.component.css'
})

export class LoginButtonComponent {
  loginService = inject(LoginService);
  router = inject(Router);

  login(){
    this.router.navigate(['login']);
  }
}