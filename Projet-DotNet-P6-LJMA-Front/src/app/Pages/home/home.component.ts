import {Component, OnInit} from '@angular/core';
import { HeaderComponent } from "../../Components/header/header.component";
import { ViewportScroller } from "@angular/common";
import { Router } from "@angular/router";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
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
