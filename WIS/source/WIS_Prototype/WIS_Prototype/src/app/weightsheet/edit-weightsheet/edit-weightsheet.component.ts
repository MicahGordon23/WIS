import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { NewWeightsheet, Weightsheet } from '../weightsheet';
import { WeightsheetService } from '../weightsheet.service';

import { CommodityType } from '../../commodity-type/commodity-type';
import { CommodityTypeService } from '../../commodity-type/commodity-type.service';

import { CommodityVariety } from '../../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../../commodity-variety/commodity-variety.service';

import { Load } from '../../load/load';
import { LoadService } from '../../load/load.service';

@Component({
  selector: 'app-edit-weightsheet',
  templateUrl: './edit-weightsheet.component.html',
  styleUrls: ['./edit-weightsheet.component.scss']
})
export class EditWeightsheetComponent {
  constructor(
    private weightsheetService: WeightsheetService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private loadService: LoadService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  form!: FormGroup;

  weightsheet!: Weightsheet;

  commodityTypes!: CommodityType[];

  commodityVarieties!: CommodityVariety[];

  loads!: Load[];

  ngOnInit() {
    this.form = new FormGroup({
      commodityTypeIdLink: new FormControl('', Validators.required),
      commodityVarietyIdLink: new FormControl(''),
      weigher: new FormControl(''),
      states: new FormControl(''),
      hauler: new FormControl(''),
      miles: new FormControl(''),
      notes: new FormControl('')
    })

    // Get the lot using id from the route.
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    let id = idParam ? +idParam : 0;
    this.weightsheetService.getWeightsheet(BigInt(id))
      .subscribe(sheet => {
        this.weightsheet = sheet;
        console.log(this.weightsheet);
        console.log('In Get Weight Sheet');
        this.form.patchValue(sheet);
      }, e => console.log(e));

    

    this.commodityTypeService.getData()
      .subscribe(commodities => {
        this.commodityTypes = commodities;
        console.log('In Get Commodity Types');
      }, e => console.log(e));

    this.loadService.getLoadsByWeightSheetId(id)
    .subscribe(result => {
      this.loads = result;
    }, error => console.log(error));
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety select field is
  //    populated with its varieties.
  onSelect(event: Event) {
    const typeId = Number(event);
    this.commodityVarietyService.getByType({ typeId })
      .subscribe(result => this.commodityVarieties = result);
  }

  onSubmit() {
    this.weightsheet.commodityTypeIdLink = this.form.controls['commodityTypeIdLink'].value;
    this.weightsheet.commodityVarietyIdLink = this.form.controls['commodityVarietyIdLink'].value;
    this.weightsheet.weigher = this.form.controls['weigher'].value;
    this.weightsheet.miles = this.form.controls['miles'].value;
    this.weightsheet.notes = this.form.controls['notes'].value;
    this.weightsheetService.put(this.weightsheet)
      .subscribe(result => {
        console.log("Updated weight sheet" + result)
      }, e => console.log(e));
    this.router.navigate(['/weightsheet']);
  }

  cancel() {
    this.router.navigate(['/weightsheet']);
  }

  onWeightSheetClose() {

    this.weightsheet.dateClosed = new Date();
    // I need this in local time PST
    // Documentation I found was incorrect.
    // Stored in UTC, but will console.log in local time
    this.weightsheet.dateClosed.setUTCHours(this.weightsheet.dateClosed.getUTCHours() - 8);
    console.log(this.weightsheet);
    this.weightsheetService.put(this.weightsheet).subscribe()
    this.router.navigate(['/weightsheet']);
  }

  onReOpen() {
    this.weightsheet.warehouseIdLink = 1;
    console.log(this.weightsheet);
    this.weightsheet.dateClosed = undefined;
    this.weightsheetService.put(this.weightsheet).subscribe()
    this.router.navigate(['/weightsheet']);
  }
}
