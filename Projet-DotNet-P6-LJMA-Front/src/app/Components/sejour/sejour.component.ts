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
  randos: Randonnee[] = [];
  error: string = " ";

  constructor(private randonneeService: RandonneeService) {}

  ngOnInit(): void {
    this.loadRandonnee();
  }

  loadRandonnee(): void {
    this.randonneeService.getRandos().subscribe({
      next: (data) => {
        this.randos = data;
        console.log('Randonnées chargées:', this.randos);
      },
      error: (err) => {
        this.error = 'Erreur lors du chargement des randonnées';
        console.error('Erreur:', err);
      }
    });
  }
}
