import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, catchError, of, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ApiHandlerService {
  constructor(private snackBar: MatSnackBar) {}

  /**
   * execute an api request with common error handling
   * @param api
   * @returns
   */
  handle<T>(api: () => Observable<T>) {
    return api().pipe(
      catchError((x) => {
        this.snackBar.open('An error occurred', 'Ok');
        return throwError(() => x);
      }),
    );
  }
}
