import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Individual } from '../../../../api/models/individual';
import { IndividualApiService } from '../../../../api/services/individual-api.service';
import { IndividualsDataSource } from './individuals.datasource';

describe('IndividualsDataSource', () => {
  let service: IndividualsDataSource;
  let individualApiServiceMock: jasmine.SpyObj<IndividualApiService>;

  let apiResponse: Individual[];
  beforeEach(async () => {
    individualApiServiceMock = jasmine.createSpyObj<IndividualApiService>([
      'getAll',
    ]);

    apiResponse = [
      {
        id: 1,
        firstName: 'First A',
        lastName: 'Last A',
        dateOfBirth: new Date('2/25/1993'),
        telephoneNumber: '123-456-7890',
        addressLine1: 'Line 1 A',
        city: 'City A',
        state: 'State A',
        zip: '12345',
        country: 'Country A',
      },
      {
        id: 2,
        firstName: 'First B',
        lastName: 'Last B',
        dateOfBirth: new Date('6/5/1963'),
        telephoneNumber: '2345678901',
        addressLine1: 'Line 1 B',
        city: 'City B',
        state: 'State B',
        zip: '23456',
        country: 'Country B',
      },
    ];

    await TestBed.configureTestingModule({
      providers: [
        IndividualsDataSource,
        {
          provide: IndividualApiService,
          useValue: individualApiServiceMock,
        },
      ],
    }).compileComponents();

    service = TestBed.inject(IndividualsDataSource);
  });

  it('should create', () => {
    expect(service).toBeTruthy();
  });

  describe('fetch', () => {
    it('should fetch and transform data', () => {
      individualApiServiceMock.getAll.and.returnValue(of(apiResponse));

      service.fetch();
      expect(individualApiServiceMock.getAll).toHaveBeenCalledOnceWith(
        jasmine.anything(),
      );
      expect(service.dataSource.data).toEqual([
        {
          id: 1,
          name: 'First A Last A',
          dateOfBirth: 'Feb 25, 1993',
          telephoneNumber: '(123) 456-7890',
        },
        {
          id: 2,
          name: 'First B Last B',
          dateOfBirth: 'Jun 5, 1963',
          telephoneNumber: '(234) 567-8901',
        },
      ]);
    });

    it('should handle empty response', () => {
      const apiResponse: Individual[] = [];
      individualApiServiceMock.getAll.and.returnValue(of(apiResponse));

      service.fetch();
      expect(individualApiServiceMock.getAll).toHaveBeenCalledOnceWith(
        jasmine.anything(),
      );
      expect(service.dataSource.data).toEqual([]);
    });
  });

  it('should filter', () => {
    individualApiServiceMock.getAll.and.returnValue(of(apiResponse));
    service.fetch();

    service.filter(' First A  ');
    expect(service.dataSource.filter).toBe('first a');
  });
});
