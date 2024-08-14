import { Component } from '@angular/core';
import { RouterModule } from "@angular/router";
import { RegisterComponent } from "./Components/register/register.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, RegisterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
}
