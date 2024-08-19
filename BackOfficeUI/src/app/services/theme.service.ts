import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Theme } from '../models/theme.model';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  private apiUrl = 'http://localhost:5101/Themes';

  constructor(private http: HttpClient) {}

   getThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>(this.apiUrl);
  }


  addTheme(Theme: Theme): Observable<Theme> {
    return this.http.post<Theme>(this.apiUrl, Theme);
  }

  updateTheme(Theme: Theme): Observable<Theme> {
    return this.http.put<Theme>(`${this.apiUrl}`, Theme);
  }

  deleteTheme(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
