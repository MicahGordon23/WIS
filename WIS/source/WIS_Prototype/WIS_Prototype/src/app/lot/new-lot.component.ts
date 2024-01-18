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
    private commodityTypeService: CommodityTypeService
  ) { }

  // The form for model
  form!: FormGroup;

  producers!: Producer[];

  commodities!: CommodityType[];

  // The new lot refernce
  lot!: Lot;

  ngOnInit() {
    this.form = new FormGroup({
      producerId: new FormControl(''),
      stateId: new FormControl(''),
      landlord: new FormControl(''),
      farmNumber: new FormControl(''),
      notes: new FormControl('')
    })

    // get for the form's select Producer field
    this.producerService.getData().subscribe(result => this.producers = result);

    // get for the form's select Commodity Type field.
    this.commodityTypeService.getData().subscribe(result => this.commodities = result);

  }

  onSubmit() {
    var lot = this.lot;
    console.log(lot);
    if (lot) {
      lot.stateId = this.form.controls['sateId'].value;
      lot.landlord = this.form.controls['landlord'].value;
      lot.farmNumber = this.form.controls['farmNumber'].value;
      lot.notes = this.form.controls['notes'].value;
    }
  }

}
