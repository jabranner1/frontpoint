import { Route } from '@angular/router';
import { individualResolver } from './services/individual.resolver';

export const ROUTES: Route[] = [
  {
    path: '',
    redirectTo: 'individuals',
    pathMatch: 'full',
  },
  {
    path: 'individuals',
    loadComponent: () =>
      import('./components/individuals/individuals.component').then(
        (x) => x.IndividualsComponent,
      ),
  },
  {
    path: 'individuals/:individualId',
    resolve: {
      individual: individualResolver,
    },
    loadComponent: () =>
      import('./components/individual/individual.component').then(
        (x) => x.IndividualComponent,
      ),
  },
];
