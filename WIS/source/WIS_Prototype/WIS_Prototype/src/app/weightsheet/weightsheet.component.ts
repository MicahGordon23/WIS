import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Weightsheet } from './weightsheet';


@Component({
  selector: 'app-weightsheet',
  templateUrl: './weightsheet.component.html',
  styleUrls: ['./weightsheet.component.scss']
})
export class WeightsheetComponent implements OnInit {
  public displayedColumns: string[] = ['weightsheetId', 'commodityTypeIdLink', 'commodityVarietyIdLink', 'ProducerIdLink', 'SourceIdLink'];
  public weightsheets!: Weightsheet[];

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.http.get<Weightsheet[]>('/api/Weightsheet')
      .subscribe(result => {
        this.weightsheets = result;
      }, error => console.error(error));
  }
}
