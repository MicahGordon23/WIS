import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';


import { Weightsheet } from './weightsheet';
import { WeightsheetService } from './weightsheet.service';


@Component({
  selector: 'app-weightsheet',
  templateUrl: './weightsheet.component.html',
  styleUrls: ['./weightsheet.component.scss']
})
export class WeightsheetComponent implements OnInit {
  // I don't know why displayColumns exist. I should find out why I added this.
  public displayedColumns: string[] = ['weightSheetId', 'commodityTypeIdLink', 'commodityVarietyIdLink', 'ProducerIdLink', 'SourceIdLink'];
  public weightsheets!: Weightsheet[];

  constructor(
    private weightsheetService: WeightsheetService
  )
    { }

  ngOnInit() {
    this.weightsheetService.getData()
      .subscribe(result => {
        this.weightsheets = result;
        console.log(result);
      }, error => console.error(error));
  }
}
