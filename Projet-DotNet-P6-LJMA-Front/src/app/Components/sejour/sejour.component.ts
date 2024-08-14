import { Component } from '@angular/core';
import {HeaderComponent} from "../header/header.component";

@Component({
  selector: 'app-sejour',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './sejour.component.html',
  styleUrl: './sejour.component.css'
})
export class SejourComponent {

}
