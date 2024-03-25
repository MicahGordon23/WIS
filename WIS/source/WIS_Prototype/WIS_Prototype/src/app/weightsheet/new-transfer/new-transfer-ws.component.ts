import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { IWeightsheet, Weightsheet, NewWeightsheet, NewWeightsheetNoVariety } from '../weightsheet';
import { WeightsheetService } from '../weightsheet.service';

import { CommodityType } from '../../commodity-type/commodity-type';
import { CommodityTypeService } from '../../commodity-type/commodity-type.service';

import { CommodityVariety } from '../../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../../commodity-variety/commodity-variety.service';

import { Source } from '../../source/source';
import { SourceService } from '../../source/source.service';

@Component({
  selector: 'app-new-transfer-ws',
  templateUrl: './new-transfer-ws.component.html',
  styleUrls: ['./new-transfer-ws.component.scss']
})
export class NewTransferWsComponent {

  form!: FormGroup;

  weightsheet!: IWeightsheet;

  // Holds array of commodity types
  commodities!: CommodityType[];

  // Holds array of commodity varieties
  varieties?: CommodityVariety[];

  sources!: Source[];

  constructor(
    private commodityTypeSerivce: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private weightsheetService: WeightsheetService,
    private sourceService: SourceService,
    private router: Router
  ) {

  }

  ngOnInit() {
    this.form = new FormGroup({
      source: new FormControl('', Validators.required),
      commodityType: new FormControl('', Validators.required),  // Synchronous Validator
      weigher: new FormControl('', Validators.required),        // Synchronous Validator

      lot: new FormControl(''),
      commodityVariety: new FormControl(''),
      hauler: new FormControl(''),
      miles: new FormControl(''),
      billOfLading: new FormControl(''),
      notes: new FormControl('')
    })

    this.commodityTypeSerivce.getData().subscribe(result => this.commodities = result);

    this.sourceService.getSources().subscribe(result => this.sources = result);
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety select field is
  //    populated with its varieties.
  onSelect(event: Event) {
    const typeId = Number(event);
    this.commodityVarietyService.getByType({ typeId })
      .subscribe(result => this.varieties = result);
  }

  //**********************************************
  // Purpose: Validates and Submits New Weightsheet form.
  onSubmit() {
    let w = new IWeightsheet();

    w.commodityTypeIdLink = this.form.controls['commodityType'].value;
    w.sourceIdLink = this.form.controls['source'].value;
    //w.warehouseIdLink = GetWarehouseId();
    w.warehouseIdLink = 1;
    w.weigher = this.form.controls['weigher'].value;
    w.hauler = this.form.controls['miles'].value;
    w.notes = this.form.controls['notes'].value;
    
    // Variety Checking.
    if (this.form.controls['commodityVariety'].value != '') {
      let _ws = new NewWeightsheet();
      _ws = w;
      _ws.commodityVarietyIdLink = this.form.controls['commodityVariety'].value;
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

  onCancel() {
    this.router.navigate(['']);
  }
}
