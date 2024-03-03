import { Component } from '@angular/core';
//import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';

//import { NewWeightsheetComponent } from '../weightsheet/new-weightsheet.component';

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
} from './load';

import { LoadService } from './load.service';

import { Bin } from '../bin/bin';
import { BinService } from '../bin/bin.service';

import { Weightsheet } from '../weightsheet/weightsheet';
import { WeightsheetService } from '../weightsheet/weightsheet.service';

import { TruckScaleService } from '../scale/truck-scale.service';

import { catchError } from 'rxjs';


@Component({
  selector: 'app-new-load',
  templateUrl: './new-load.component.html',
  styleUrls: ['./new-load.component.scss']
})
export class NewLoadComponent {
  constructor(
    //private weightsheetDialog: MatDialog,
    //private dialogRef: MatDialogRef<NewLoadComponent>,
    private loadService: LoadService,
    private binService: BinService,
    private weightsheetService: WeightsheetService,
    private truckScaleService: TruckScaleService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  // The form model
  form!: FormGroup;

  // the new load ref
  load!: ILoad;

  // Bin options for select
  bins!: Bin[];

  weightSheetId!: bigint;

  ngOnInit() {

    this.form = new FormGroup({
      truckId: new FormControl('', Validators.required),      // Syncronous Validator
      bin: new FormControl('', Validators.required),          // Syncronous Validator
      
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protienLevel: new FormControl(''),
      bolNumber: new FormControl(''),
      notes: new FormControl('')
    });

    // Gets Bins for the associated warehouse in this case 1
    this.binService.getWarehouseBins(1)
      .subscribe(result => this.bins = result);

    // retrieve the ID from the 'id' parameter
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.weightSheetId = BigInt(idParam ? +idParam : 0);
  }

  onSubmit() {
    var load = new ILoad();
    if (load) {
      
      // Local variables hold value. Less overhead from the linq
      let moisture = this.form.controls['moistureLevel'].value;
      let testWeight = this.form.controls['testWeight'].value;
      let protienLevel = this.form.controls['protienLevel'].value;

      // To Do optimize the conditionals. Very Ugly
      if (moisture != '' && testWeight != '' && protienLevel != '') {
        let loadA = new LoadMoistureTestWeightProtien();
        loadA.moistureLevel = moisture;
        loadA.protienLevel = protienLevel;
        loadA.testWeight = testWeight;
        load = loadA;

      } else if (moisture != '') {
        let loadM = new LoadMoisture();
        loadM.moistureLevel = moisture;
        load = loadM;

      } else if (testWeight != '') {
        let loadTw = new LoadTestWeight();
        loadTw.testWeight = testWeight;
        load = loadTw;

      } else if (protienLevel != '') {
        let loadPl = new LoadProtien();
        loadPl.protienLevel = protienLevel;
        load = loadPl;

      } else if (moisture != '' && testWeight != '') {
        let loadMTw = new LoadMoistureTestWeight();
        loadMTw.moistureLevel = moisture;
        loadMTw.testWeight = testWeight;
        load = loadMTw;

      } else if (moisture != '' && protienLevel != '') {
        let loadMPl = new LoadMoistureProtien();
        loadMPl.moistureLevel = moisture;
        loadMPl.protienLevel = protienLevel;
        load = loadMPl;

      } else if (testWeight != '' && protienLevel != '') {
        let loadTwPl = new LoadTestWeightProtein();
        loadTwPl.testWeight = testWeight;
        loadTwPl.protienLevel = protienLevel;
        load = loadTwPl;
      }
    }
    load.truckId = this.form.controls['truckId'].value;
    load.timeIn = new Date();
    // Account for Local Time
    load.timeIn.setHours(load.timeIn.getUTCHours() - 8);
    load.billOfLading = this.form.controls['bolNumber'].value;
    load.notes = this.form.controls['notes'].value;
    load.binIdLink = this.form.controls['bin'].value;
    //load.weightsheetIdLink = this.form.controls['weightsheet'].value;
    this.load = load
    this.load.weightsheetIdLink = this.weightSheetId;
    this.load.grossWeight = this.truckScaleService.getWeight();
    // Post load
    this.loadService.post(this.load)
      .subscribe(error => console.log(error));
    console.log(this.load);
    //this.dialogRef.close();
  }

  //openNewWeightsheetDialog(): void {
  //  const dialogConfig = new DialogConfig();
  //  let dialogRef = this.weightsheetDialog.open(NewWeightsheetComponent, {});
  //}



  onCancel(): void {
   // this.dialogRef.close();
  }

}
