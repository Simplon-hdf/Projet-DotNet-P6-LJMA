import {Component} from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { FormsModule } from "@angular/forms";
import {RandonneeService} from "../../Services/randonnee.service";
import {Randonnee} from "../../Models/randonnee";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-sejour',
  standalone: true,
  imports: [
    HeaderComponent,
    FormsModule,
    NgForOf,
  ],
  templateUrl: './sejour.component.html',
  styleUrl: './sejour.component.css'
})

export class SejourComponent {
  title = 'Randonnées';
  randos: Randonnee[] = [];

  constructor(private randonneeService: RandonneeService) {}

  ngOnInit(): void {
    this.getRandos();
  }

  getRandos(): void {
    this.randonneeService.getRandos().subscribe(
      (result: Randonnee[]) => {
        this.randos = result;
      },
      (error) => {
        console.error('Error fetching randos:', error);
      }
    );
  }
}
