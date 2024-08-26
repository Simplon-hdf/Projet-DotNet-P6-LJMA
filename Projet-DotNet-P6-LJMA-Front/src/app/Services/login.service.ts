import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserCredentials } from '../Models/auth.model';
import { map, Observable, tap } from 'rxjs';

export interface CredentialsResponse {
  token: string;
  message: string;
}

export interface CredentialsOnToken {
  nameid: string; //"nameid": "e9307acc-0bb9-490c-bc15-0b80967702e0",
  unique_name: string; //"unique_name": "Admin",
  given_name: string; //"given_name": "System",
  role: string; //"role": "AdminExemple",
  nbf: number; //"nbf": 1724366410,
  exp: number; //"exp": 1724452810,
  iat: number; //"iat": 1724366410
}

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private http = inject(HttpClient);
  private BASE_URL = 'http://localhost:5101';
  user = signal<CredentialsOnToken | null | undefined>(undefined);
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  decodedToken(): CredentialsOnToken | null {
    const helper = new JwtHelperService();
    return helper.decodeToken<CredentialsOnToken | null>(this.getToken()!);
  }

  login(credentials: UserCredentials): Observable<CredentialsOnToken | null | undefined> {
    return this.http
      .post(this.BASE_URL + '/api/Authentifications/authenticate', credentials)
      .pipe(
        tap((result: any) => {
          localStorage.setItem('token', result.token);
          this.user.set(this.decodedToken());
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
