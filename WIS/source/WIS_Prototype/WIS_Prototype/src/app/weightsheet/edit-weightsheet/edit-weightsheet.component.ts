import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
      commodityTypeId: new FormControl('', Validators.required),
      commodityVarietyId: new FormControl(''),
      weigher: new FormControl(''),
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
        this.form.patchValue(this.weightsheet);
      }, e => console.log(e));

    this.commodityTypeService.getData()
      .subscribe(commodities => {
        this.commodityTypes = commodities;
      }, e => console.log(e));

    this.loadService.getLoadsByWeightSheetId(id)
      .subscribe(result => {
        this.loads = result
      }, error => console.log(error));
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety select field is
  //    populated with its varieties.
  onSelect(event: Event) {
    const typeId = Number((event.target as HTMLInputElement).value);
    this.commodityVarietyService.getByType(typeId)
      .subscribe(result => this.commodityVarieties = result);
  }

  onSubmit() {
    this.weightsheet.commodityTypeIdLink = this.form.controls['commodityTypeId'].value;
    this.weightsheet.commodityVarietyIdLink = this.form.controls['commodityVarietyId'].value;
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
}
