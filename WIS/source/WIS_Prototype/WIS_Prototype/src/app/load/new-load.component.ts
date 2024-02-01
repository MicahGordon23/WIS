import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';

import { NewWeightsheetComponent } from '../weightsheet/new-weightsheet.component';

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
    private weightsheetDialog: MatDialog,
    private dialogRef: MatDialogRef<NewLoadComponent>,
    private loadService: LoadService,
    private binService: BinService,
    private weightsheetService: WeightsheetService,
    private truckScaleService: TruckScaleService
  ) { }

  // The form model
  form!: FormGroup;

  // the new load ref
  load!: ILoad;

  bins!: Bin[];

  weightsheets!: Weightsheet[];

  ngOnInit() {

    this.form = new FormGroup({
      truckId: new FormControl(''),
      bin: new FormControl(''),
      weightsheet: new FormControl(''),
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protienLevel: new FormControl(''),
      bolNumber: new FormControl(''),
      notes: new FormControl('')
    });

    // Gets Bins for the associated warehouse in this case 1
    this.binService.getWarehouseBins(1)
      .subscribe(result => this.bins = result);

    this.weightsheetService.getData()
      .subscribe(result => this.weightsheets = result);
  }

  onSubmit() {
    var load = new ILoad();
    if (load) {
      // generate load id? or do this before for when clicking new laod?
      // Controller gets the id service does the math
      // Http Get from scale. Scale Service/Controller Most likely a controller here
      

      // Local variables hold value. Less overhead from the linq
      let moisture = this.form.controls['moistureLevel'].value;
      let testWeight = this.form.controls['testWeight'].value;
      let protienLevel = this.form.controls['protienLevel'].value;

      // To Do optimize the conditionals. Very Ugly
      if (moisture != '' && testWeight != '' && protienLevel != '') {
        let loadA = new NewLoad();
        loadA.moistureLevel = moisture;
        loadA.protienLevel = protienLevel;
        loadA.testWeight = testWeight;
        load = loadA;

      } else if (moisture != '') {
        let loadM = new NewLoadMoisture();
        loadM.moistureLevel = moisture;
        load = loadM;

      } else if (testWeight != '') {
        let loadTw = new NewLoadTestWeight();
        loadTw.testWeight = testWeight;
        load = loadTw;

      } else if (protienLevel != '') {
        let loadPl = new NewLoadProtien();
        loadPl.protienLevel = protienLevel;
        load = loadPl;

      } else if (moisture != '' && testWeight != '') {
        let loadMTw = new NewLoadMoistureTestWeight();
        loadMTw.moistureLevel = moisture;
        loadMTw.testWeight = testWeight;
        load = loadMTw;

      } else if (moisture != '' && protienLevel != '') {
        let loadMPl = new NewLoadMoistureProtien();
        loadMPl.moistureLevel = moisture;
        loadMPl.protienLevel = protienLevel;
        load = loadMPl;

      } else if (testWeight != '' && protienLevel != '') {
        let loadTwPl = new NewLoadTestWeightProtein();
        loadTwPl.testWeight = testWeight;
        loadTwPl.protienLevel = protienLevel;
        load = loadTwPl;
      }
    }
    load.truckId = this.form.controls['truckId'].value;
    load.timeIn = new Date();
    load.bolNumber = this.form.controls['bolNumber'].value;
    load.notes = this.form.controls['notes'].value;
    this.load = load

    this.load.grossWeight = this.truckScaleService.getWeight();
    // Post load
    this.loadService.post(this.load)
      .subscribe(error => console.log(error));
    console.log(this.load);
    this.dialogRef.close();
  }

  openNewWeightsheetDialog(): void {
    const dialogConfig = new DialogConfig();
    let dialogRef = this.weightsheetDialog.open(NewWeightsheetComponent, {});
  }



  onCancel(): void {
    this.dialogRef.close();
  }

}
