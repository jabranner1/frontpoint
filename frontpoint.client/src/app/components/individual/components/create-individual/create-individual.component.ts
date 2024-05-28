import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Individual } from '../../../../../api/models/individual';
import { PageTitleComponent } from '../../../common/page-title/page-title.component';
import { IndividualFormComponent } from '../individual-form/individual-form.component';

@Component({
  selector: 'app-create-individual',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    PageTitleComponent,
    IndividualFormComponent,
  ],
  templateUrl: './create-individual.component.html',
  styleUrl: './create-individual.component.scss',
})
export class CreateIndividualComponent {
  constructor(private router: Router) {}

  handleFormComplete(individual: Individual | undefined) {
    this.router.navigate(['/individuals']);
  }
}
