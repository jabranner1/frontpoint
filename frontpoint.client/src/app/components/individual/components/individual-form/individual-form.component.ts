import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { BehaviorSubject } from 'rxjs';
import { Individual } from '../../../../../api/models/individual';
import { IndividualApiService } from '../../../../../api/services/individual-api.service';
import { Mode } from '../../../../models/mode';
import { NamePipe } from '../../../../pipes/name.pipe';
import { ApiHandlerService } from '../../../../services/api-handler.service';
import { TelephoneInputComponent } from '../../../common/telephone-input/telephone-input.component';
import { IndividualForm } from '../../models/individual-form';
import { IndividualFormFactory } from '../../services/individual-form.factory';

@Component({
  selector: 'app-individual-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    TelephoneInputComponent,
    MatIconModule,
    MatButtonModule,
    NamePipe,
  ],
  providers: [IndividualFormFactory],
  templateUrl: './individual-form.component.html',
  styleUrl: './individual-form.component.scss',
})
export class IndividualFormComponent {
  readonly form: IndividualForm;
  readonly saving$ = new BehaviorSubject<boolean>(false);

  @Input() individual?: Individual;
  @Input() mode: Mode = 'edit';

  @Output() canceled = new EventEmitter<Individual>();
  @Output() saved = new EventEmitter<Individual>();

  constructor(
    factory: IndividualFormFactory,
    private apiHandlerService: ApiHandlerService,
    private individualApiService: IndividualApiService,
  ) {
    this.form = factory.create();
  }

  ngOnInit() {
    if (this.individual) this.form.patchValue(this.individual);
  }

  save() {
    this.form.markAllAsTouched();
    this.saving$.next(true);
    if (!this.form.valid) return;
    this.apiHandlerService
      .handle(() => this.getApiRequest())
      .subscribe({
        next: (individual) => {
          this.saving$.next(false);
          this.saved.emit(individual);
        },
        error: () => {
          this.saving$.next(false);
        },
      });
  }

  cancel() {
    this.canceled.emit(this.individual);
  }

  private getApiRequest() {
    return this.mode === 'create'
      ? this.individualApiService.create(this.form.value)
      : this.individualApiService.update(
          this.form.value.id ?? -1,
          this.form.value,
        );
  }
}
