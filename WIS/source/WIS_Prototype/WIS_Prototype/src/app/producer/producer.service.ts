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

  url: string = '/api/Producers';
  producers!: Producer[];

  // Gets all producers if producers is not already populated. 
  getProducers(): Producer[] {
    if (this.producers == undefined || this.producers == null) {
      this.getData().subscribe(result => {
        console.log("Producers from backend");
        this.producers = result;
        return this.producers;
      }, error => console.log(error));
    }
    console.log("Producer from service");
    return this.producers;
  }
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
