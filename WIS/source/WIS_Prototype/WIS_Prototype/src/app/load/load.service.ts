import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';
import { Load } from './load';

// The decortate passing root makes this a singleton.
@Injectable({
  providedIn: 'root',
})

export class LoadService extends BaseService<Load> {
  constructor(http: HttpClient) {
    super(http);
  }

  getData(): Observable<ApiResult<Load>> {
    var url = this.getUrl("api/Loads");
    return this.http.get<ApiResult<Load>>(url, {});
  }

  get(id: bigint): Observable<Load> {
    var url = this.getUrl("api/Load");
    return this.http.get<Load>(url);
  }

  put(item: Load): Observable<Load> {
    var url = this.getUrl("api/Loads" + item.loadId);
    return this.http.put<Load>(url, item);
  }

  post(item: Load): Observable<Load> {
    var url = this.getUrl("api/Loads");
    return this.http.post<Load>(url, item);
  }
}
