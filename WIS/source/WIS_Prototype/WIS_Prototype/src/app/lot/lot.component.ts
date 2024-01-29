import { Component, OnInit } from '@angular/core';

import { Lot } from './lot';
import { LotService } from './lot.service';

@Component({
  selector: 'app-lot',
  templateUrl: './lot.component.html',
  styleUrls: ['./lot.component.scss']
})

export class LotComponent implements OnInit {
  //public displayColumns: string[] = ['Lot Id', 'Produ']
  public lots!: Lot[];

  constructor(
    private lotService: LotService
  ) { }

  ngOnInit() {
    this.lotService.getData()
      .subscribe(result => {
        this.lots = result;
      }, error => console.error(error));
  }
}
