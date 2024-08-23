import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Session } from '../models/session.model';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private apiUrl = 'http://localhost:5101/Sessions';

  constructor(private http: HttpClient) {}

   getSessions(): Observable<Session[]> {
    return this.http.get<Session[]>(this.apiUrl);
  }

  getSessionById(sessionId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${sessionId}`);
  }

  addSession(Session: Session): Observable<Session> {
    return this.http.post<Session>(this.apiUrl, Session);
  }

  updateSession(Session: Session): Observable<Session> {
    return this.http.put<Session>(`${this.apiUrl}`, Session);
  }

  deleteSession(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
