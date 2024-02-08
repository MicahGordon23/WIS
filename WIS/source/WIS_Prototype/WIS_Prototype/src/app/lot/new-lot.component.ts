import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';

import { ILot, Lot, NewLot, NewLotNoVariety } from './lot';
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

  states = [
    { value: 'ID', viewValue: 'ID' },
    { value: "WA", viewValue: 'WA' },
    { value: 'OR', viewValue: 'OR' }
  ];

  // The new lot refernce
  lot!: ILot;

  ngOnInit() {
    // Initialize form
    this.form = new FormGroup({
      producer: new FormControl('', Validators.required),
      commodityType: new FormControl('', Validators.required),
      commodityVariety: new FormControl(''),
      stateId: new FormControl('', Validators.required),
      landlord: new FormControl(''),
      farmNumber: new FormControl(''),
      notes: new FormControl('')
    })

    // get for the form's select Producer field
    this.producerService.getData().subscribe(result => this.producers = result);

    // get for the form's select Commodity Type field.
    this.commodityTypeService.getData().subscribe(result => this.commodities = result);
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in 
  onSelect(event: Event) {
    const typeId = Number((event.target as HTMLInputElement).value);
    this.commodityVarietyService.getByType(typeId)
      .subscribe(result => this.varieties = result);
  }

  //**********************************************
  // Purpose: Submit form
  onSubmit() {
    // Highest Level of lot. miniumn extentions 
    let lot = new ILot();

    lot.producerIdLink = this.form.controls['producer'].value;
    lot.commodityTypeIdLink = this.form.controls['commodityType'].value;
    lot.stateId = this.form.controls['stateId'].value;
    lot.landlord = this.form.controls['landlord'].value;
    lot.farmNumber = this.form.controls['farmNumber'].value;
    lot.notes = this.form.controls['notes'].value;

    if (this.form.controls['commodityVariety'].value != '') {
      let _lot = new NewLot();
      _lot = lot;
      _lot.commodityVarietyIdLink = this.form.controls['commodityVariety'].value;
      //lot.commodityVarietyIdLink = this.form.controls['commodityVariety'].value;
      // ?Downcast to NewLot from ILot I think
      lot = _lot;
    }
    
    lot.startDate = new Date();

    this.lot = lot;
    console.log(this.lot);

    this.lotService.post(this.lot)
      .subscribe(result => {
        console.log("Lot Added")
      }, error => console.error(error));
  }

}
