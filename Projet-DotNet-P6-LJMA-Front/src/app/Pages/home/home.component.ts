import {Component, inject, OnInit} from '@angular/core';
import { HeaderComponent } from "../../Components/header/header.component";
import { ViewportScroller } from "@angular/common";
import {Router, RouterLink} from "@angular/router";
import {SejourComponent} from "../../Components/sejour/sejour.component";
import { LoginService } from '../../Services/login.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
    SejourComponent,
    RouterLink,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  loginService = inject(LoginService);
  
  constructor(private scroller: ViewportScroller, private route : Router) {}

  ngOnInit() {
    this.route.navigate(["/"]);
  }

  goDown() {
    const about = document.getElementById("about");
    // @ts-ignore
    about.scrollIntoView({
      behavior: "smooth",
      block: "start",
      inline: "nearest"
    })
  }
}
