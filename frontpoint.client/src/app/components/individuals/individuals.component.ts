import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Router, RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import { Individual } from '../../../api/models/individual';
import { PageTitleComponent } from '../common/page-title/page-title.component';
import { IndividualsDataSource } from './services/individuals.datasource';

@Component({
  selector: 'app-individuals',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatDividerModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    PageTitleComponent,
  ],
  providers: [IndividualsDataSource],
  templateUrl: './individuals.component.html',
  styleUrl: './individuals.component.scss',
})
export class IndividualsComponent {
  public individuals$!: Observable<Individual[]>;

  displayedColumns: string[] = ['name', 'birth', 'number'];
  get dataSource$() {
    return this.individualDataSource.dataSource$;
  }

  constructor(
    private individualDataSource: IndividualsDataSource,
    private router: Router,
  ) {}

  ngOnInit() {
    this.individualDataSource.fetch();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.individualDataSource.filter(filterValue);
  }

  initiateCreate() {
    this.router.navigate(['/individuals', 'create']);
  }
}
