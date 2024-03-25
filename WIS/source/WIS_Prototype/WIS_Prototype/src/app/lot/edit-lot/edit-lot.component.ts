import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { LotDto, Lot } from '../../lot/lot';
import { LotService } from '../lot.service';

import { Producer } from '../../producer/producer';
import { ProducerService } from '../../producer/producer.service';

import { CommodityType } from '../../commodity-type/commodity-type';
import { CommodityTypeService } from '../../commodity-type/commodity-type.service';

import { CommodityVariety } from '../../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../../commodity-variety/commodity-variety.service';

import { States } from '../../states/states';

@Component({
  selector: 'app-edit-lot',
  templateUrl: './edit-lot.component.html',
  styleUrls: ['./edit-lot.component.scss']
})
export class EditLotComponent {
  constructor(
    private lotService: LotService,
    private producerService: ProducerService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {
     //this.states = new States();
  }

  form!: FormGroup;

  lot!: LotDto;

  producers!: Producer[];

  commodityTypes!: CommodityType[];

  commodityVarieties!: CommodityVariety[];

  states = [
    { value: 'ID', viewValue: 'ID' },
    { value: "WA", viewValue: 'WA' },
    { value: 'OR', viewValue: 'OR' }
  ];

  ngOnInit() {
    this.form = new FormGroup({
      producerId : new FormControl('', Validators.required),
      commodityTypeId: new FormControl('', Validators.required),
      commodityVarietyId: new FormControl(''),
      stateId: new FormControl('', Validators.required),
      landlord: new FormControl(''),
      farmNumber: new FormControl(''),
      notes: new FormControl('')
    })

    // Get the lot using id from the route.
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    let id = idParam ? +idParam : 0;

    //this.producers = this.producerService.getProducers()
    //console.log(this.producers);

    this.lotService.getLotDto(BigInt(id))
      .subscribe(lot => {
        this.lot = lot as LotDto;
        this.commodityVarietyService.getByType({ typeId: lot.commodityTypeId })
          .subscribe(result => {
            console.log(result);
            this.commodityVarieties = result;
          }, error => console.log(error));

        console.log("In Lot Subscribe.");
        console.log(this.lot);
        this.form.patchValue(this.lot);
      }, error => console.log(error));

    this.producerService.getData()
      .subscribe(result => {
        console.log("In Producer Subscribe.");
        this.producers = result;
        console.log(this.producers);
      }, e => console.log(e));

    this.commodityTypeService.getData()
      .subscribe(result => {
        this.commodityTypes = result;
      }, e => console.log(e));

   
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety field is populated.
  onTypeSelect(event: Event) {
    const typeId = Number(event);
    this.commodityVarietyService.getByType({ typeId })
      .subscribe(result => {
        this.commodityVarieties = result;
      }, e => console.log(e));
  }

  //**********************************************
  // Purpose: Submit Form. Updates database.
  onSubmit() {
    let lot = new Lot();
    lot = this.lot;
    console.log(lot);
    if (this.form.controls['producerId'].value != '') {
      lot.producerIdLink = this.form.controls['producerId'].value;
    }
    if (this.form.controls['commodityTypeId'].value != '') {
      lot.commodityTypeIdLink = this.form.controls['commodityTypeId'].value;
    }
    // will cause bug if removing variety
    if (this.form.controls['commodityVarietyId'].value != '') {
      lot.commodityVarietyIdLink = this.form.controls['commodityVarietyId'].value;
    }
    lot.stateId = this.form.controls['stateId'].value;
    lot.landlord = this.form.controls['landlord'].value;
    lot.farmNumber = this.form.controls['farmNumber'].value;
    lot.notes = this.form.controls['notes'].value;
    lot.endDate = undefined;
    lot.warehouseIdLink = 1;
    console.log(lot);
    this.lotService.put(lot).subscribe(result => {
      console.log(result);
    }, e => console.log(e));
    this.route.navigate(['/lot']);
  }

  onCancel() {
    this.route.navigate(['/lot']);
  }

  onLotClose() {
    this.lot.endDate = new Date();
    console.log(this.lot.endDate);
    // I need this in local time PST
    // Documentation I found was incorrect.
    // Stored in UTC, but will console.log in local time
    this.lot.endDate.setUTCHours(this.lot.endDate.getUTCHours() - 8);
    this.lotService.put(this.lot).subscribe();
    this.route.navigate(['/lot']);
  }

  onReOpen() {
    this.lot.endDate = undefined;
    this.lotService.put(this.lot).subscribe();
    this.route.navigate(['/lot']);
  }
}
