import { Injectable } from '@angular/core';
import {HttpClient, HttpEvent} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../Environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http : HttpClient) { }

  get<T>(URL : string): Observable<T> {
    return this.http.get<T>(environment.apiBaseUrl + URL);
  }

  post<T>(URL : string, body:any): Observable<HttpEvent<T>> {
    return this.http.get<T>(environment.apiBaseUrl + URL, body);
  }

  put<T>(URL : string, body:any): Observable<HttpEvent<T>> {
    return this.http.get<T>(environment.apiBaseUrl + URL, body);
  }

  delete<T>(URL : string): Observable<T> {
    return this.http.get<T>(environment.apiBaseUrl + URL);
  }
}
