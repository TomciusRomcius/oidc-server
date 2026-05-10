import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatAnchor, MatButton } from "@angular/material/button";

@Component({
  selector: 'app-page',
  imports: [MatCardModule, MatAnchor, MatButton],
  templateUrl: './page.html',
  styleUrl: './page.css',
})
export class Page {}
