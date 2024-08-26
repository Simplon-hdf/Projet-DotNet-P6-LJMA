import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface User {
  id: string;
  prenom: string;
  nom: string;
  telephone: string;
  email: string;
  role: string;
}

@Injectable({
  providedIn: 'root',
})
export class UtilisateurService {
  private http = inject(HttpClient);
  private BASE_URL = 'http://localhost:5101';

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.BASE_URL + '/Utilisateurs');
  }

  getUserById(userId: string): Observable<any> {
    return this.http.get<any>(`${this.BASE_URL}/Utilisateurs/${userId}`);
  }

  putUser(userUpdated: User) {
    return this.http.put(this.BASE_URL+'/Utilisateurs', userUpdated);
  }

  deleteUser(id: string) {
    return this.http.delete(this.BASE_URL+'/Utilisateurs/'+id);
  }
}
