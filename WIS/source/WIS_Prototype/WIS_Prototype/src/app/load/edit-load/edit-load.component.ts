import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Bin } from '../../bin/bin';
import { BinService } from '../../bin/bin.service';

import { Weightsheet } from '../../weightsheet/weightsheet';
import { WeightsheetService } from '../../weightsheet/weightsheet.service';

import { TruckScaleService } from '../../scale/truck-scale.service';

// Load related imports
import {
  ILoad,
  Load,
  NewLoad,
  NewLoadMoisture,
  NewLoadTestWeight,
  NewLoadProtien,
  NewLoadMoistureTestWeight,
  NewLoadMoistureProtien,
  NewLoadTestWeightProtein
} from '../load';
import { LoadService } from '../load.service';

import { from } from 'rxjs';

@Component({
  selector: 'app-edit-load',
  templateUrl: './edit-load.component.html',
  styleUrls: ['./edit-load.component.scss']
})
export class EditLoadComponent {

  constructor(
    private loadService: LoadService,
    private binService: BinService,
    private weightsheetService: WeightsheetService,
    private scaleService: TruckScaleService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  form!: FormGroup;

  // refernce to load being editied
  load!: ILoad;

  // Bin options for select
  bins!: Bin[];

  // Weightsheet options for select
  weightsheets!: Weightsheet[];

  // On Init
  ngOnInit() {
    this.form = new FormGroup({
      truckId: new FormControl(''),
      bin: new FormControl(''),
      weightsheet: new FormControl(''),
      grossWeight: new FormControl(''),
      tareWeight: new FormControl(''),
      netWeight: new FormControl(''),
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protienLevel: new FormControl(''),
      bolNumber: new FormControl(''),
      notes: new FormControl('')
    });

    // retrieve the ID from the 'id' parameter
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    var id = idParam ? +idParam : 0;

    // Gets Bins for the associated warehouse in this case 1
    this.binService.getWarehouseBins(1)
      .subscribe(result => this.bins = result);

    // Gets open Weightsheets
    // Harded code for warehouse 1
    this.weightsheetService.getWarehouseOpenWeigthsheets(1)
      .subscribe(result => this.weightsheets = result);

    // Retreived load from server
    this.loadService.get(BigInt(id))
      .subscribe(result => {
        this.load = result;
        console.log(this.load);
        // update form.
        this.form.patchValue(this.load);
      }, error => console.log(error))
  }


  // Weigh Out
  weighOut() {

  }

  // Done
  onSubmit() {

  }

  // Cancel edit
  onCancel() {
    this.route.navigate(['/load'])
  }
}
