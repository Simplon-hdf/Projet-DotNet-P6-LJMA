import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserRegister } from '../Models/reg.model';
import { map, Observable, tap } from 'rxjs';

export interface CredentialsOnToken {
  nameid: any;
  unique_name: string;
  given_name: string;
  role: string;
  nbf: number;
  exp: number;
  iat: number;
}

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private http = inject(HttpClient);
  private BASE_URL = 'http://localhost:5101'
  user = signal<CredentialsOnToken | null | undefined>(undefined);

  getToken(): string | null {
    const token = localStorage.getItem('token');
    if (token && token.split('.').length === 3) {
      return token;
    }
    return null;
  }

  decodedToken(): CredentialsOnToken | null {
    const helper = new JwtHelperService();
    const token = this.getToken();
    if (token) {
      try {
        return helper.decodeToken<CredentialsOnToken>(token);
      } catch (error) {
        console.error('Error decoding token:', error);
        return null;
      }
    }
    return null;
  }

  register(credentials: UserRegister) {
    return this.http.post(this.BASE_URL + '/Utilisateurs', credentials).pipe(
      tap((result: any) => {
        localStorage.setItem('token', result.token);
        this.user.set(this.decodedToken());
        console.table(result);
      }),
      map((result: any) => {
        return this.user();
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.user.set(undefined);
  }
}
