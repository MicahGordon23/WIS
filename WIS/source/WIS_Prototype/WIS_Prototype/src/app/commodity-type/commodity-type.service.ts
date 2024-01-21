import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { CommodityType } from './commodity-type';

@Injectable({
  providedIn: 'root'
})

export class CommodityTypeService {

  //*************************
  // Ctor
  constructor(private http: HttpClient) {

  }

  // Url property keep this DRY
  private url: string = '/api/CommodityTypes';
  
  //*************************
  // Get ALL
  getData(): Observable<CommodityType[]> {
    return this.http.get<CommodityType[]>(this.url, {});
  }
}
