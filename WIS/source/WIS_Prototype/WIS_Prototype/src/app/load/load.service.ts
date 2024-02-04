import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';

import { ILoad, Load } from './load';

// The decortate passing root makes this a singleton.
@Injectable({
  providedIn: 'root',
})

export class LoadService {
  constructor(private http: HttpClient) {
  }

  private url: string = "/api/Loads";

  getData(): Observable<Load[]> {
    return this.http.get<Load[]>(this.url, {});
  }

  get(id: bigint): Observable<Load> {
    return this.http.get<Load>(this.url + '/' + id);
  }

  put(item: Load): Observable<Load> {
    return this.http.put<Load>(this.url + item.loadId, item);
  }

  post(item: ILoad): Observable<ILoad> {
    return this.http.post<ILoad>(this.url, item);
  }
}
