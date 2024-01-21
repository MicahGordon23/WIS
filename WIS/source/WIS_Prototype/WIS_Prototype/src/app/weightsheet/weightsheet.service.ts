import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';
import { Weightsheet } from './weightsheet';

// The decortate passing root makes this a singleton.
@Injectable({
  providedIn: 'root',
})

export class WeightsheetService{
  constructor(private http: HttpClient) {
  }

  private url: string = "/api/Weightsheets";

  getData(): Observable<Weightsheet[]> {
   
    return this.http.get<Weightsheet[]>(this.url, {});
  }

  get(id: bigint): Observable<Weightsheet> {
    
    return this.http.get<Weightsheet>(this.url);
  }

  put(item: Weightsheet): Observable<Weightsheet> {
    return this.http.put<Weightsheet>(this.url + item.weightSheetId, item);
  }

  post(item: Weightsheet): Observable<Weightsheet> {
    return this.http.post<Weightsheet>(this.url, item);
  }
}
