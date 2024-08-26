import { Component, inject, OnDestroy } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { Subscription } from 'rxjs';
import { LoginService } from './login.service';
import { UserCredentials } from '../../models/auth.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, MatInputModule, MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnDestroy {
  private formBuilder = inject(FormBuilder);
  private loginService = inject(LoginService);
  private router = inject(Router);
  private loginSubscription: Subscription | null = null;

  loginFormGroup = this.formBuilder.group({
    email: ['', [Validators.required]],
    motdepasse: ['', [Validators.required]],
  });
  invalidCredentials = false;

  login() {
    this.loginSubscription = this.loginService
      .login(this.loginFormGroup.value as UserCredentials)
      .subscribe({
        next: (result) => {
          this.router.navigate(['general']);
        },
        error: (error) => {
          // console.error(error.error.status);
          // console.table(error.error.errors);
          this.invalidCredentials = true;
        },
      });
  }

  ngOnDestroy(): void {
    this.loginSubscription?.unsubscribe();
  }
}
