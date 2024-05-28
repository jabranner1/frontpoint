import { Injectable } from '@angular/core';
import { ApiBaseService } from './api-base.service';
import { Individual } from '../models/individual';

@Injectable({ providedIn: 'root' })
export class IndividualApiService extends ApiBaseService<Individual> {
  protected ROOT = '/api/individuals';
}
