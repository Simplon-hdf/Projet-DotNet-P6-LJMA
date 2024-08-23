import {Component, inject, OnDestroy} from '@angular/core';
import { Router } from "@angular/router";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import { UserRegister } from "../../Models/reg.model";
import {MatButton} from "@angular/material/button";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {RegisterService} from "../../Services/register.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-register',
  standalone: true,
    imports: [
        FormsModule,
        MatButton,
        MatError,
        MatFormField,
        MatInput,
        MatLabel,
        ReactiveFormsModule,
    ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnDestroy {
  private formBuilder = inject(FormBuilder);
  private registerService = inject(RegisterService);
  private registerSubscription: Subscription | null = null;
  private router = inject(Router);

  registerFormGroup = this.formBuilder.group({
    nom: ['', Validators.required],
    prenom: ['', Validators.required],
    telephone: ['', Validators.required],
    email: ['', Validators.required],
    motdepasse: ['', Validators.required],
  });

  register() {
    if (this.registerFormGroup.valid) {
      const userRegister: UserRegister = this.registerFormGroup.value as UserRegister;
      this.registerSubscription = this.registerService
        .register(userRegister)
        .subscribe({
          next: (result) => {
            console.table(result);
            if (result) {
              this.router.navigate(['home']);
            } else {
              console.log('Registration failed: No result returned');
            }
          },
          error: (error) => {
            console.error('Registration error:', error);
            // Optionally display an error message to the user
          },
        });
    } else {
      console.log('Form is invalid');
      Object.values(this.registerFormGroup.controls).forEach(control => {
        control.markAsTouched();
      });
    }
  }

  ngOnDestroy() {
    this.registerSubscription?.unsubscribe();
  }
}
