import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { Lot } from './lot';
import { LotService } from './lot.service';

import { Producer } from '../producer/producer';
import { ProducerService } from '../producer/producer.service';

import { CommodityType } from '../commodity-type/commodity-type';
import { CommodityTypeService } from '../commodity-type/commodity-type.service';

import { CommodityVariety } from '../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../commodity-variety/commodity-variety.service';

@Component({
  selector: 'app-new-lot',
  templateUrl: './new-lot.component.html',
  styleUrls: ['./new-lot.component.scss']
})

export class NewLotComponent {
  constructor(
    private dialogRef: MatDialogRef<NewLotComponent>,
    private http: HttpClient,
    private lotService: LotService,
    private producerService: ProducerService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService
  ) { }

  // The form for model
  form!: FormGroup;

  producers!: Producer[];

  commodities!: CommodityType[];

  varieties?: CommodityVariety[];

  // The new lot refernce
  lot!: Lot;

  ngOnInit() {
    this.form = new FormGroup({
      producer: new FormControl(''),
      commodityType: new FormControl(''),
      commodityVariety: new FormControl(''),
      stateId: new FormControl(''),
      landlord: new FormControl(''),
      farmNumber: new FormControl(''),
      notes: new FormControl('')
    })

    // get for the form's select Producer field
    this.producerService.getData().subscribe(result => this.producers = result);

    // get for the form's select Commodity Type field.
    this.commodityTypeService.getData().subscribe(result => this.commodities = result);

    this.varieties;
  }

  onSelect(event: Event) {
    // const filterValue = (event.target as HTMLInputElement).value;
    const typeId = Number((event.target as HTMLInputElement).value);
    this.commodityVarietyService.getByType(typeId)
      .subscribe(result => this.varieties = result);
    
  }

  //onSelect(typeId: number) {
  //  this.commodityVarietyService.getByType(typeId).subscribe(result => this.varieties = result);
  //}

  onSubmit() {
    let lot = <Lot>{}
;
    lot.producerIdLink = this.form.controls['producer'].value;
    lot.commodityTypeIdLink = this.form.controls['commodityType'].value;
    lot.commodityVarietyIdLink = this.form.controls['commodityVariety'].value;
    lot.stateId = this.form.controls['stateId'].value;
    lot.landlord = this.form.controls['landlord'].value;
    lot.farmNumber = this.form.controls['farmNumber'].value;
    lot.notes = this.form.controls['notes'].value;

    this.lot = lot;
    console.log(this.lot);
  }

}
