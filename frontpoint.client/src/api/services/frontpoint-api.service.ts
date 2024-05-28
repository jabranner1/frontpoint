import { Injectable, inject } from '@angular/core';
import { IndividualApiService } from './individual-api.service';

@Injectable({ providedIn: 'root' })
export class FrontpointApiService {
  public readonly individual = inject(IndividualApiService);
}
