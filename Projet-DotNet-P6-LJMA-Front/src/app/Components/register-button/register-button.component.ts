import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-register-button',
  standalone: true,
    imports: [
        RouterLink
    ],
  templateUrl: './register-button.component.html',
  styleUrl: './register-button.component.css'
})
export class RegisterButtonComponent {

}
