import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Weightsheet } from '../weightsheet';
import { WeightsheetService } from '../weightsheet.service';

import { CommodityType } from '../../commodity-type/commodity-type';
import { CommodityTypeService } from '../../commodity-type/commodity-type.service';

import { CommodityVariety } from '../../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../../commodity-variety/commodity-variety.service';

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
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  form!: FormGroup;

  weightsheet!: Weightsheet;

  commodityTypes!: CommodityType[];

  commodityVarieties!: CommodityVariety[];

  ngOnInit() {
    this.form = new FormGroup({
      commodityTypeId: new FormControl('', Validators.required),
      commodityVarietyId: new FormControl(''),
      weigher: new FormControl(''),
      hauler: new FormControl(''),
      billofLading: new FormControl(''),
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
  }

  //**********************************************
  // Purpose: When a Commodity Type is selected in the form, the variety field is populated.
  onSelect(event: Event) {
    const typeId = Number((event.target as HTMLInputElement).value);
    this.commodityVarietyService.getByType(typeId)
      .subscribe(result => this.commodityVarieties = result);
  }

  onSubmit() {

  }
}
