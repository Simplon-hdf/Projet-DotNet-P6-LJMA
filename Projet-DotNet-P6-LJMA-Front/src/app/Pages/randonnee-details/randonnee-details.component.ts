import {Component, OnInit} from '@angular/core';
import {Randonnee} from "../../Models/randonnee.model";
import {ActivatedRoute} from "@angular/router";
import {RandonneeService} from "../../Services/randonnee.service";

@Component({
  selector: 'app-randonnee-details',
  standalone: true,
  imports: [],
  templateUrl: './randonnee-details.component.html',
  styleUrl: './randonnee-details.component.css'
})
export class RandonneeDetailsComponent implements OnInit {
  randonnee!: Randonnee;
  constructor(private route: ActivatedRoute, private randonneeService: RandonneeService) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam !== null) {
        const id = parseInt(idParam, 10);
        if (!isNaN(id)) {
          this.loadRandonnee(id);
        } else {
          console.error('ID invalide');
          // Gérer le cas d'un ID invalide (redirection, message d'erreur, etc.)
        }
      }
    });
  }

  loadRandonnee(id: number): void {
    this.randonneeService.getRandonneeById(id).subscribe({
      next: (data) => {
        this.randonnee = data;
      },
      error: (err) => {
        console.log('Erreur lors du chargement de la randonnée:', err);
      }
    })
  }
}
