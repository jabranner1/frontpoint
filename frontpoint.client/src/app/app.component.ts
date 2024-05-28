import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, MatToolbarModule],
  template: `
    <mat-toolbar class="header">
      <span>Frontpoint</span>
    </mat-toolbar>

    <div class="main">
      <router-outlet></router-outlet>
    </div>

    <mat-toolbar class="footer"> </mat-toolbar>
  `,
  styleUrl: './app.component.scss',
})
export class AppComponent {}
