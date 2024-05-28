import { TestBed } from '@angular/core/testing';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiHandlerService } from './api-handler.service';
import { of, throwError } from 'rxjs';

describe('ApiHandlerService', () => {
  let service: ApiHandlerService;
  let matSnackBarMock: jasmine.SpyObj<MatSnackBar>;

  beforeEach(async () => {
    matSnackBarMock = jasmine.createSpyObj<MatSnackBar>(['open']);

    await TestBed.configureTestingModule({
      providers: [
        ApiHandlerService,
        {
          provide: MatSnackBar,
          useValue: matSnackBarMock,
        },
      ],
    }).compileComponents();

    service = TestBed.inject(ApiHandlerService);
  });

  it('should create', () => {
    expect(service).toBeTruthy();
  });

  it('should notify error', () => {
    const apiMock = () => throwError(() => 'an error');
    service
      .handle(() => apiMock())
      .subscribe({
        error: (x) => {
          expect(x).toBe('an error');
          expect(matSnackBarMock.open).toHaveBeenCalledOnceWith(
            'An error occurred',
            'Ok',
          );
        },
      });
  });

  it('should handle success', () => {
    const apiMock = () => of(true);
    service
      .handle(() => apiMock())
      .subscribe({
        next: (x) => {
          expect(x).toBeTrue();
          expect(matSnackBarMock.open).not.toHaveBeenCalled();
        },
      });
  });
});
