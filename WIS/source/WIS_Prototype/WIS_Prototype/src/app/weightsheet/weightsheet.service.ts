import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';
import { IWeightsheet, Weightsheet, WeightsheetOverview } from './weightsheet';

// The decortate passing root makes this a singleton.
@Injectable({
  providedIn: 'root',
})

export class WeightsheetService{
  constructor(private http: HttpClient) {
  }

  private url: string = "/api/Weightsheets";

  // Gets all Weightsheets from the database.
  getData(): Observable<Weightsheet[]> {

    return this.http.get<Weightsheet[]>(this.url, {});
  }

  getOverview(warehouseId: number): Observable<WeightsheetOverview[]> {
    let url = this.url + "/Overview/" + warehouseId;
    return this.http.get<WeightsheetOverview[]>(url);
  }

  // Gets all Open Weightsheets for warehouseId From the database. An open weightsheet has no close
  //  date.
  getWarehouseOpenWeigthsheets(warehouseId: number): Observable<Weightsheet[]> {
    return this.http.get<Weightsheet[]>(this.url + '/Open/' + warehouseId);
  }

  // Gets a single Weightsheet by weightsheetId from the database.
  getWeightsheet(id: bigint): Observable<Weightsheet> {
    
    return this.http.get<Weightsheet>(this.url + '/' + id);
  }

  // Edit a single weightsheet. Updated it in the databse
  put(item: Weightsheet): Observable<Weightsheet> {
    return this.http.put<Weightsheet>(this.url + '/' + item.weightSheetId, item);
  }

  // Add a new weightsheet to the database.
  // Takes an IWeightsheet to account for nullables in the non-nullable by C# fields. Example:
  //    Closed date will not be set on creation, but C# is rejecting a null there. Therfore use
  //    a different weightsheet object with no dateClosed field.
  post(item: IWeightsheet): Observable<IWeightsheet> {
    return this.http.post<IWeightsheet>(this.url, item);
  }
}
