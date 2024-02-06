import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { NewLotComponent } from '../lot/new-lot.component'

import { IWeightsheet, Weightsheet, NewWeightsheet, NewWeightsheetNoVariety } from './weightsheet';
import { WeightsheetService } from './weightsheet.service';

import { CommodityType } from '../commodity-type/commodity-type';
import { CommodityTypeService } from '../commodity-type/commodity-type.service';

import { CommodityVariety } from '../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../commodity-variety/commodity-variety.service';

import { Lot } from '../lot/lot';
import { LotService } from '../lot/lot.service';

@Component({
  selector: 'app-new-weightsheet',
  templateUrl: './new-weightsheet.component.html',
  styleUrls: ['./new-weightsheet.component.scss']
})
export class NewWeightsheetComponent {
  constructor(
    private lotDialog: MatDialog,
    private dialogRef: MatDialogRef<NewWeightsheetComponent>,
    private weightsheetService: WeightsheetService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private lotService: LotService,
  ) { }

  form!: FormGroup;

  // Weightsheet which will hold the form
  weightsheet!: IWeightsheet;

  // Holds list of lots
  lots?: Lot[];

  // Holds array of commodity types
  commodities!: CommodityType[];

  // Holds array of commodity varieties
  varieties?: CommodityVariety[];

  ngOnInit() {
    this.form = new FormGroup({
      commodityType: new FormControl('', Validators.required),  // Synchronous Validator
      weigher: new FormControl('', Validators.required),        // Synchronous Validator

      lot: new FormControl(''),
      commodityVariety: new FormControl(''),
      hauler: new FormControl(''),
      miles: new FormControl(''),
      billOfLading: new FormControl(''),
      notes: new FormControl('')
    })

    // Gets lots for the Forms select lot field
    this.lotService.getData().subscribe(result => this.lots = result);

    // Gets the list for the form's select Commodity Type field.
    this.commodityTypeService.getData().subscribe(result => this.commodities = result);
  }

  //**********************************************
  // Purpose: Opens a new Dialog window containting New Lot form.
  openNewLotDialog(): void {
    const dialogConfig = new DialogConfig();
    let dialogRef = this.lotDialog.open(NewLotComponent, {});
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety select field is
  //    populated with its varieties.
  onSelect(event: Event) {
    const typeId = Number((event.target as HTMLInputElement).value);
    this.commodityVarietyService.getByType(typeId)
      .subscribe(result => this.varieties = result);
  }

  //**********************************************
  // Purpose: Validates and Submits New Weightsheet form.
  onSubmit() {
    let w = new IWeightsheet();

    w.commodityTypeIdLink = this.form.controls['commodityType'].value;
    //w.warehouseIdLink = GetWarehouseId();
    w.warehouseIdLink = 1;
    w.weigher = this.form.controls['weigher'].value;
    w.hauler = this.form.controls['miles'].value;
    w.billOfLading = this.form.controls['billOfLading'].value;
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

    this.weightsheet = w;

    this.weightsheetService.post(this.weightsheet)
      .subscribe(result => {
        console.log("Weightsheet Added")
      }, error => console.log(error));
    this.dialogRef.close();
  }

  //**********************************************
  // Closes the New Weightsheet dialog window
  onCancel(): void {
    this.dialogRef.close();
  }
}
