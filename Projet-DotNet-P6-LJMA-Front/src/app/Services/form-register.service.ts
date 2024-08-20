import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from "../Environments/environment";
import { UserRegister } from '../Models/reg.model';

@Injectable({
  providedIn: 'root',
})

export class FormRegisterService {
  private Url = environment.apiBaseUrl + '/Utilisateurs';
  FormData: UserRegister = new UserRegister();
  constructor(public http: HttpClient) {}

  postEnregistrer() {
    return this.http.post(this.Url, this.FormData);
  }
}
