import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Producer } from './producer';

@Injectable({
  providedIn: 'root'
})
export class ProducerService {

  //Ctor
  constructor(private http: HttpClient) { }

  //*******************************
  // GET all
  getData(): Observable<Producer[]> {
    var url = '/api/Producers';
    return this.http.get<Producer[]>(url, {});
  }

  //*******************************
  // POST new Producer
  post(item: Producer): Observable<Producer> {
    var url = '/api/Producers';
    return this.http.post<Producer>(url, item);
  }

  //*******************************
  // PUT update/new Producer
  put(item: Producer): Observable<Producer> {
    var url = '/api/Producers';
    return this.http.put<Producer>(url, item);
  }
}
