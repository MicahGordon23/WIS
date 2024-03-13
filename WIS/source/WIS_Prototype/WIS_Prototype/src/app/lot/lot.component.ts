import { Component, OnInit } from '@angular/core';

import { LotDto } from './lot';
import { LotService } from './lot.service';
import { CommodityType } from '../commodity-type/commodity-type';
import { CommodityTypeService } from '../commodity-type/commodity-type.service';
import { CommodityVariety } from '../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../commodity-variety/commodity-variety.service';
import { Producer } from '../producer/producer';
import { ProducerService } from '../producer/producer.service';

@Component({
  selector: 'app-lot',
  templateUrl: './lot.component.html',
  styleUrls: ['./lot.component.scss']
})

export class LotComponent implements OnInit {
  //public displayColumns: string[] = ['Lot Id', 'Produ']
  public lots!: LotDto[];

  warehouseId: bigint;

  constructor(

    private lotService: LotService
  ) {
    this.warehouseId = BigInt(1);
  }

  ngOnInit() {
    this.lotService.getAllLotDto(this.warehouseId)
      .subscribe(result => {
        this.lots = result;
      }, error => console.error(error));
  }
}
