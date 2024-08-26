// src/app/services/reserver.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Reserver } from '../models/reserver.model';

@Injectable({
  providedIn: 'root'
})
export class ReserverService {
  private apiUrl = 'http://localhost:5101/Reservers'; // Remplacez par l'URL de votre API

  constructor(private http: HttpClient) { }

  getAllReservations(): Observable<Reserver[]> {
    return this.http.get<Reserver[]>(`${this.apiUrl}`).pipe(
      catchError(this.handleError<Reserver[]>('getAllReservations', []))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} a échoué:`, error);
      return of(result as T);
    };
  }
}