import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatAnchor, MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-page',
  imports: [MatCardModule, MatAnchor, MatButton, RouterLink],
  templateUrl: './page.html',
  styleUrl: './page.css',
})
export class Page {}
