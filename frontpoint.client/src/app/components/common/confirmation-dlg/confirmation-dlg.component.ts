import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'frontpoint-confirmation-dlg',
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatDialogModule],
  template: `<h2 mat-dialog-title>{{ title }}</h2>
    <mat-dialog-content class="mat-typography">
      <p>{{ message }}</p>
    </mat-dialog-content>
    <mat-dialog-actions align="end">
      <button mat-button mat-dialog-close *ngIf="cancelBtn">
        {{ cancelBtn }}
      </button>
      <button mat-button [mat-dialog-close]="true" cdkFocusInitial>
        {{ confirmationBtn }}
      </button>
    </mat-dialog-actions>`,
  styleUrl: './confirmation-dlg.component.scss',
})
export class ConfirmationDlgComponent {
  @Input() title: string = '';
  @Input() message: string = '';
  @Input() confirmationBtn: string = 'Okay';
  @Input() cancelBtn: string = 'Cancel';
}
