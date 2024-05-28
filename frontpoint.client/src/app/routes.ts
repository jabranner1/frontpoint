import { Route } from '@angular/router';

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
];
