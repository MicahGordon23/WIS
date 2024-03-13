import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ILot, Lot, LotDto } from './lot';

@Injectable({
  providedIn: 'root'
})
export class LotService {

  //*************************
  // Ctor
  constructor(private http: HttpClient) { }
  url = '/api/Lots';
  //*************************
  // Get ALL
  getData(): Observable<Lot[]> {
    var url = '/api/Lots';
    return this.http.get<ILot[]>(url, {});
  }

  //**************************
  // Get return as DTO
  getLotDto(lotId: bigint): Observable<LotDto> {
    return this.http.get<LotDto>(this.url + '/Dto/' + lotId, {})
  }

  getAllLotDto(warehouseId: bigint): Observable<LotDto[]> {
    return this.http.get<LotDto[]>(this.url + '/Dto/Warehouse/' + warehouseId, {});
  }

  //**************************
  // Get all open lots for a warehouse
  getOpenLotsByWarehouse(warehouseId: number): Observable<LotDto[]> {
    let url = this.url + '/Open/Dto/' + warehouseId;
    return this.http.get<LotDto[]>(url, {});
  }

  //**************************
  // Get lot by id
  getLot(lotId: bigint): Observable<Lot> {
    return this.http.get<Lot>(this.url + '/' + lotId, {})
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
    let url = this.url + '/' + item.lotId
    console.log(item);
    return this.http.put<Lot>(url, item);
    //return this.http.put<Lot>(url, item);
  }
}
