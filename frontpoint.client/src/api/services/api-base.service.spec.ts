import {
  HttpTestingController,
  provideHttpClientTesting,
} from '@angular/common/http/testing';
import { Injectable } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { ApiBaseService } from './api-base.service';
import { provideHttpClient } from '@angular/common/http';

describe('ApiBaseService', () => {
  interface TestData {
    id?: number;
  }
  @Injectable()
  class TestApiService extends ApiBaseService<TestData> {
    protected ROOT = '/api/test';
  }

  let service: TestApiService;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [
        provideHttpClient(),
        provideHttpClientTesting(),
        TestApiService,
      ],
    }).compileComponents();

    httpMock = TestBed.inject(HttpTestingController);
    service = TestBed.inject(TestApiService);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(service).toBeTruthy();
  });

  it('should get all', () => {
    const response: TestData[] = [{ id: 1 }, { id: 2 }];

    service.getAll().subscribe((x) => {
      expect(x).toEqual(response);
    });
    const req = httpMock.expectOne('/api/test');
    expect(req.request.method).toEqual('GET');
    req.flush(response);
  });

  it('should get', () => {
    const response: TestData = { id: 1 };

    service.get(1).subscribe((x) => {
      expect(x).toEqual(response);
    });
    const req = httpMock.expectOne('/api/test/1');
    expect(req.request.method).toEqual('GET');
    req.flush(response);
  });

  it('should create', () => {
    const request: TestData = { id: 1 };
    const response: TestData = { id: 1 };

    service.create(request).subscribe((x) => {
      expect(x).toEqual(response);
    });
    const req = httpMock.expectOne('/api/test');
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(request);
    req.flush(response);
  });

  it('should update', () => {
    const request: TestData = { id: 1 };
    const response: TestData = { id: 1 };

    service.update(1, request).subscribe((x) => {
      expect(x).toEqual(response);
    });
    const req = httpMock.expectOne('/api/test/1');
    expect(req.request.method).toEqual('PUT');
    expect(req.request.body).toEqual(request);
    req.flush(response);
  });

  it('should delete', () => {
    service.delete(1).subscribe();
    const req = httpMock.expectOne('/api/test/1');
    expect(req.request.method).toEqual('DELETE');
    req.flush('');
  });
});
