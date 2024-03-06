import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { IWeightsheet, Weightsheet, NewWeightsheet, NewWeightsheetNoVariety } from '../weightsheet';
import { WeightsheetService } from '../weightsheet.service';

import { CommodityType } from '../../commodity-type/commodity-type';
import { CommodityTypeService } from '../../commodity-type/commodity-type.service';

import { CommodityVariety } from '../../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../../commodity-variety/commodity-variety.service';

import { Lot } from '../../lot/lot';
import { LotService } from '../../lot/lot.service';

@Component({
  selector: 'app-new-inbound-ws',
  templateUrl: './new-inbound-ws.component.html',
  styleUrls: ['./new-inbound-ws.component.scss']
})
export class NewInboundWsComponent {
  constructor(
    private weightsheetService: WeightsheetService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private lotService: LotService,
    private activeRoute: ActivatedRoute,
    private router: Router,
  ) {
    // Get the lot using id from the route.
    let idParam = this.activeRoute.snapshot.paramMap.get('id');
    this.lotId = BigInt(idParam ? +idParam : 0);
  }

  // Lot Id Number
  lotId: bigint;

  // form
  form!: FormGroup;

  // Weightsheet which will hold the form
  weightsheet!: IWeightsheet;

  // Holds lot which the weightsheet will be a child of 
  lot!: Lot;

  ngOnInit() {
    this.form = new FormGroup({
      weigher: new FormControl('', Validators.required),        // Synchronous Validator
      lot: new FormControl(''),
      commodityVariety: new FormControl(''),
      hauler: new FormControl(''),
      miles: new FormControl(''),
      billOfLading: new FormControl(''),
      notes: new FormControl('')
    })

    // Gets lots for the Forms select lot field
    this.lotService.getLot(this.lotId).subscribe(result => this.lot = result);
  
  }

  //**********************************************
  // Purpose: Validates and Submits New Weightsheet form.
  onSubmit() {
    let w = new IWeightsheet();

    w.commodityTypeIdLink = this.lot.commodityTypeIdLink;
    //w.warehouseIdLink = GetWarehouseId();
    w.warehouseIdLink = this.lot.warehouseIdLink;
    w.weigher = this.form.controls['weigher'].value;
    w.hauler = this.form.controls['miles'].value;
    w.notes = this.form.controls['notes'].value;
    w.lotIdLink = this.lot.lotId;

    // Variety Checking.
    if (this.lot.commodityVarietyIdLink != null) {
      let _ws = new NewWeightsheet();
      _ws = w;
      _ws.commodityVarietyIdLink = this.lot.commodityVarietyIdLink;
      // Cast w to NewWeightsheet
      w = _ws;
    }
    w.dateOpened = new Date();
    console.log(w.dateOpened);
    // I need this in local time PST
    // Documentation I found was incorrect.
    // Stored in UTC, but will console.log in local time
    w.dateOpened.setUTCHours(w.dateOpened.getUTCHours() - 8);
    console.log(w.dateOpened);
    this.weightsheet = w;

    this.weightsheetService.post(this.weightsheet)
      .subscribe(result => {
        console.log("Weightsheet Added")
      }, error => console.log(error));
    //this.dialogRef.close();
    this.router.navigate(['']);
  }

  //**********************************************
  // Closes the New Weightsheet dialog window
  onCancel(): void {
    //this.dialogRef.close();
    this.router.navigate(['']);
  }
}
