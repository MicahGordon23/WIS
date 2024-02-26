import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ILot, Lot } from './lot';

@Injectable({
  providedIn: 'root'
})
export class LotService {

  //*************************
  // Ctor
  constructor(private http: HttpClient) { }

  //*************************
  // Get ALL
  getData(): Observable<Lot[]> {
    var url = '/api/Lots';
    return this.http.get<Lot[]>(url, {});
  }

  //**************************
  // Get top id number
  getTop(): Observable<Lot> {
    var url = '/api/Lots/top';
    return this.http.get<Lot>(url, {});
  }

  //**************************
  // POST new lot
  post(item: ILot): Observable<ILot> {
    var url = '/api/Lots';
    console.log(item);
    return this.http.post<ILot>(url, item);
  }

  //**************************
  // PUT update/new lot
  put(item: Lot): Observable<Lot> {
    var url = '/api/Lots';
    return this.http.put<Lot>(url + "/" + item.lotId, item);
  }
}
