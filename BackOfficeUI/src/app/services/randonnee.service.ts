import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Randonnee } from '../models/randonnee.model';

@Injectable({
  providedIn: 'root'
})
export class RandonneeService {

  private apiUrl = 'http://localhost:5101/Randonnee';

  constructor(private http: HttpClient) {}

   getRandonnees(): Observable<Randonnee[]> {
    return this.http.get<Randonnee[]>(this.apiUrl);
  }


  addRandonnee(randonnee: Randonnee): Observable<Randonnee> {
    return this.http.post<Randonnee>(this.apiUrl, randonnee);
  }

  updateRandonnee(randonnee: Randonnee): Observable<Randonnee> {
    return this.http.put<Randonnee>(`${this.apiUrl}`, randonnee);
  }

  deleteRandonnee(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}