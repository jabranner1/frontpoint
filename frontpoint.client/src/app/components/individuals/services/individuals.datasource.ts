import { Injectable } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BehaviorSubject, delay, map, retry, retryWhen, take } from 'rxjs';
import { IndividualGridItem } from '../models/individual-grid-item';
import { DatePipe } from '@angular/common';
import { Individual } from '../../../../api/models/individual';
import { NamePipe } from '../../../pipes/name.pipe';
import { PhonePipe } from '../../../pipes/phone.pipe';
import { IndividualApiService } from '../../../../api/services/individual-api.service';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class IndividualsDataSource {
  private static namePipe = new NamePipe();
  private static datePipe = new DatePipe('en-US');
  private static phonePipe = new PhonePipe();

  private _dataSource$ = new BehaviorSubject<MatTableDataSource<
    IndividualGridItem,
    MatPaginator
  > | null>(null);
  get dataSource() {
    const value = this._dataSource$.value;
    if (!value) throw new Error('invalid datasource');
    return value;
  }

  /**
   * individual data source
   */
  get dataSource$() {
    return this._dataSource$.asObservable();
  }
  constructor(private individualApiService: IndividualApiService) {}

  /**
   * populate data source
   */
  fetch() {
    this._dataSource$.next(null);
    this.individualApiService
      .getAll({
        params: new HttpParams().set('take', 10000).set('skip', 0),
      })
      .pipe(
        retry({ count: 5, delay: 500 }),
        map((individuals) => individuals.map(this.toGridItem)),
      )
      .subscribe((x) => this._dataSource$.next(new MatTableDataSource(x)));
  }

  /**
   * filter data source
   * @param value
   */
  filter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  private toGridItem(x: Individual): IndividualGridItem {
    return {
      id: x.id,
      name: IndividualsDataSource.namePipe.transform({
        prefix: x.prefix,
        first: x.firstName ?? '',
        middle: x.middleName,
        last: x.lastName ?? '',
      }),
      dateOfBirth:
        IndividualsDataSource.datePipe.transform(x.dateOfBirth) ?? '',
      telephoneNumber:
        IndividualsDataSource.phonePipe.transform(x.telephoneNumber ?? '') ??
        '',
    };
  }
}
