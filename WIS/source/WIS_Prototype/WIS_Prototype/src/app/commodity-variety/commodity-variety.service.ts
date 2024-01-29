import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { CommodityVariety } from './commodity-variety';

@Injectable({
  providedIn: 'root'
})

export class CommodityVarietyService {

  //*************************
  // Ctor
  constructor(private http: HttpClient) {

  }

  private url: string = '/api/CommodityVarieties';

  //*************************
  // Get ALL
  getData(): Observable<CommodityVariety[]> {
    return this.http.get<CommodityVariety[]>(this.url, {});
  }

  getByType(typeId: number): Observable<CommodityVariety[]> {
    return this.http.get<CommodityVariety[]>(this.url + '/Type/' + typeId, {})
  }
}
