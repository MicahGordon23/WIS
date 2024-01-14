import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Lot } from './lot';

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
    var url = '/api/Lot';
    return this.http.get<Lot[]>(url, {});
  }

  //**************************
  // POST new lot
  post(item: Lot): Observable<Lot> {
    var url = '/api/Lot';
    return this.http.post<Lot>(url, item);
  }

  //**************************
  // PUT update/new lot
  put(item: Lot): Observable<Lot> {
    var url = '/api/Lot';
    return this.http.put<Lot>(url, item);
  }

}
