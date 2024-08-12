import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterModule } from "@angular/router";
import {HomePageComponent} from "./Components/home-page/home-page.component";
import {HeaderComponent} from "./Components/header/header.component";
import {AboutPageComponent} from "./Components/about-page/about-page.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, HomePageComponent, HeaderComponent, AboutPageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}
