import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export abstract class ApiBaseService<TData> {
  protected abstract ROOT: string;

  constructor(private http: HttpClient) {}

  /**
   * gets all items
   * @returns
   */
  getAll(options?: { params?: HttpParams }) {
    return this.http.get<TData[]>(this.ROOT, {
      params: options?.params,
    });
  }

  /**
   * get item
   * @param id
   * @returns
   */
  get(id: number, options?: { params?: HttpParams }) {
    return this.http.get<TData>(
      `${this.ROOT}/${encodeURIComponent(String(id))}`,
      {
        params: options?.params,
      },
    );
  }

  /**
   * create item
   * @param value
   * @returns
   */
  create(value: TData, options?: { params?: HttpParams }) {
    return this.http.post<TData>(this.ROOT, value, {
      params: options?.params,
    });
  }

  /**
   * update item
   * @param id
   * @param value
   * @returns
   */
  update(id: number, value: TData, options?: { params?: HttpParams }) {
    return this.http.put<TData>(
      `${this.ROOT}/${encodeURIComponent(String(id))}`,
      value,
      {
        params: options?.params,
      },
    );
  }

  /**
   * delete item
   * @param id
   * @returns
   */
  delete(id: number, options?: { params?: HttpParams }) {
    return this.http.delete(`${this.ROOT}/${encodeURIComponent(String(id))}`, {
      params: options?.params,
    });
  }
}
