import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { IndividualApiService } from '../../api/services/individual-api.service';
import { retry } from 'rxjs';
import { Individual } from '../../api/models/individual';

export const individualResolver: ResolveFn<Individual> = (route) => {
  const individualId = +(route.paramMap.get('individualId') ?? '');
  return inject(IndividualApiService)
    .get(individualId)
    .pipe(retry({ count: 5, delay: 500 }));
};
