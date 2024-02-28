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
  LoadMoistureTestWeightProtien,
  LoadMoisture,
  LoadTestWeight,
  LoadProtien,
  LoadMoistureTestWeight,
  LoadMoistureProtien,
  LoadTestWeightProtein
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
    // Get current scale weight from scale.
    this.load.tareWeight = this.scaleService.getWeight();

    // Net = Gross (Heavy) - Tare (Light)
    this.load.netWeight = this.load.grossWeight - this.load.tareWeight;

    // add addtional property though polymorphism.
    let l = new Load();
    l = this.load
    l.timeOut = new Date();
    this.load = l;
    console.log(this.load);
    // Update load in the server/database
    this.loadService.put(this.load).subscribe(result => {
      console.log(result);
    }, error => console.log(error));

    this.route.navigate(['/load'])
  }

  // Done
  onSubmit() {
    console.log(this.load);
    let load = this.load as Load;
    //if
    load.grossWeight = this.form.controls['grossWeight'].value;
    load.tareWeight = this.form.controls['tareWeight'].value;
    load.truckId = this.form.controls['truckId'].value;
    load.billOfLading = this.form.controls['bolNumber'].value;
    load.binIdLink = this.form.controls['bin'].value;
    load.notes = this.form.controls['notes'].value;
    load.moistureLevel = this.form.controls['moistureLevel'].value;
    load.testWeight = this.form.controls['testWeight'].value;
    load.protienLevel = this.form.controls['protienLevel'].value;

    this.loadService.put(load)
      .subscribe(result => {
        console.log("Load Update: " + result);
      }, e => console.log(e));

    this.route.navigate(['/load'])
  }

  // Cancel edit
  onCancel() {
    this.route.navigate(['/load'])
  }
}
