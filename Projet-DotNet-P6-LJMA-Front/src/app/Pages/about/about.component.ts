import { Component } from '@angular/core';
import {HeaderComponent} from "../../Components/header/header.component";

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {

}
