import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from "../Environments/environment";
import { UserCredentials } from "../Models/auth.model";

@Injectable({
  providedIn: 'root',
})
export class FormLoginService {
  private Url = environment.apiBaseUrl + '/api/Authentifications/authenticate';

  constructor(private http: HttpClient) {}

  getLogin(email: string, motDePasse: string): Observable<any> {
    return this.http.post(this.Url, {email: email, motDePasse: motDePasse} as UserCredentials);
  }
}
