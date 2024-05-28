import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'frontpoint-page-title',
  standalone: true,
  imports: [CommonModule, MatDividerModule],
  template: `
    <h1 class="align-center"><ng-content></ng-content></h1>
    <mat-divider></mat-divider>
  `,
  styleUrl: './page-title.component.scss',
})
export class PageTitleComponent {}
