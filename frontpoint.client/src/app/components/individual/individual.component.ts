import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Individual } from '../../../api/models/individual';
import { Mode } from '../../models/mode';
import { NamePipe } from '../../pipes/name.pipe';
import { PageTitleComponent } from '../common/page-title/page-title.component';
import { IndividualFormComponent } from './components/individual-form/individual-form.component';
import { Router, RouterModule } from '@angular/router';
import { IndividualRecordComponent } from './components/individual-record/individual-record.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ConfirmationDlgComponent } from '../common/confirmation-dlg/confirmation-dlg.component';
import { IndividualApiService } from '../../../api/services/individual-api.service';
import { ApiHandlerService } from '../../services/api-handler.service';

@Component({
  selector: 'app-individual',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatDialogModule,
    NamePipe,
    PageTitleComponent,
    IndividualRecordComponent,
    IndividualFormComponent,
  ],
  templateUrl: './individual.component.html',
  styleUrl: './individual.component.scss',
})
export class IndividualComponent {
  @Input() individual!: Individual;
  @Input() mode: Mode = 'view';

  constructor(
    private dialog: MatDialog,
    private apiHandlerService: ApiHandlerService,
    private individualApiService: IndividualApiService,
    private router: Router,
  ) {}

  initiateEdit() {
    this.mode = 'edit';
  }

  initiateDelete() {
    const dialogRef = this.dialog.open(ConfirmationDlgComponent);
    dialogRef.componentInstance.title = 'Delete?';
    dialogRef.componentInstance.message =
      'Are you sure you want to delete this individual?';
    dialogRef.componentInstance.confirmationBtn = 'Delete';

    dialogRef.afterClosed().subscribe((result) => {
      if (result) this.delete();
    });
  }

  handleFormCompleteEvent(individual: Individual) {
    this.individual = individual;
    this.mode = 'view';
  }

  private delete() {
    this.apiHandlerService
      .handle(() => this.individualApiService.delete(this.individual.id ?? -1))
      .subscribe(() => {
        this.router.navigate(['/individuals']);
      });
  }
}
