import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';
import { Weightsheet } from './weightsheet';

// The decortate passing root makes this a singleton.
@Injectable({
  providedIn: 'root',
})

export class WeightsheetService extends BaseService<Weightsheet> {
  constructor(http: HttpClient) {
    super(http);
  }

  getData(): Observable<ApiResult<Weightsheet>> {
    var url = this.getUrl("api/Weightsheet");
    return this.http.get<ApiResult<Weightsheet>>(url, {});
  }

  get(id: bigint): Observable<Weightsheet> {
    var url = this.getUrl("api/Weightsheet");
    return this.http.get<Weightsheet>(url);
  }

  put(item: Weightsheet): Observable<Weightsheet> {
    var url = this.getUrl("api/Weightsheet" + item.weightsheetId);
    return this.http.put<Weightsheet>(url, item);
  }

  post(item: Weightsheet): Observable<Weightsheet> {
    var url = this.getUrl("api/Weightsheet");
    return this.http.post<Weightsheet>(url, item);
  }
}
