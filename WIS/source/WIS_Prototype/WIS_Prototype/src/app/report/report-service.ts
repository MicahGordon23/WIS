import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IntakeReport } from './intake-report';

@Injectable({
  providedIn: 'root',
})

export class ReportService {
  constructor(private http: HttpClient) {
  }

  private url: string = "/api/Reports/";

  // Generates a Warehouse Intake Report for given warehouse
  getIntakeReport(warehosueId: number): Observable<IntakeReport[]> {
    return this.http.get<IntakeReport[]>(this.url + '/Intake/' + warehosueId);
  }
}
