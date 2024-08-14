import { Component } from '@angular/core';
import { RouterLink } from "@angular/router";
import { HeaderComponent } from "../../Components/header/header.component";
import {SejourComponent} from "../../Components/sejour/sejour.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    RouterLink,
    HeaderComponent,
    SejourComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
