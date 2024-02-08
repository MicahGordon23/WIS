import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Bin } from './bin';

@Injectable({
  providedIn: 'root'
})
export class BinService {

  constructor(private http: HttpClient) { }

  private url: string = "/api/Bins";

  getData(): Observable<Bin[]> {
    return this.http.get<Bin[]>(this.url, {});
  }

  getWarehouseBins(warehouseId: number): Observable<Bin[]> {
    return this.http.get<Bin[]>(this.url + "/Warehouse/" + warehouseId, {});
  }
}
