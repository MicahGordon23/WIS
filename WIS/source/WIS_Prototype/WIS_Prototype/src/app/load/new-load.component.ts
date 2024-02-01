import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';

import { NewWeightsheetComponent } from '../weightsheet/new-weightsheet.component';

import {
  ILoad, Load, NewLoad, NewLoadMoistureTestWeight,
  NewLoadMoisture
} from './load';
import { LoadService } from './load.service';

import { Bin } from '../bin/bin';
import { BinService } from '../bin/bin.service';

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
    private BinService: BinService
  ) { }

  // The form model
  form!: FormGroup;

  // the new load ref
  load!: ILoad;

  bins!: Bin[];

  ngOnInit() {

    this.form = new FormGroup({
      truckId: new FormControl(''),
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protienLevel: new FormControl(''),
      bolNumber: new FormControl(''),
      notes: new FormControl('')
    });

    // Gets Bins for the associated warehouse in this case 1
    this.BinService.getWarehouseBins(1);
  }

  onSubmit() {
    var load = new ILoad();
    if (load) {
      // generate load id? or do this before for when clicking new laod?
      // Controller gets the id service does the math
      // Http Get from scale. Scale Service/Controller Most likely a controller here
      load.truckId = this.form.controls['truckId'].value;
      load.timeIn = new Date();
      load.bolNumber = this.form.controls['bolNumber'].value;
      load.notes = this.form.controls['notes'].value;

      // Local variables hold value. Less overhead from the linq
      let moisture = this.form.controls['moistureLevel'].value;
      let testWeight = this.form.controls['testWeight'].value;
      let protienLevel = this.form.controls['protienLevel'].value;

      // If Moistuer Level field has a value
      if (moisture != '') {

        // If Test Weight field has a value
        if (testWeight != '') {

          // If the Protien Level field has a value
          if (protienLevel != '') {

            let incomingLoad = new NewLoad();
            // Has all the properties
            incomingLoad.moistureLevel = moisture;
            incomingLoad.testWeight = testWeight;
            incomingLoad.protienLevel = protienLevel;

            load = incomingLoad;
          }
          else {
            // Has Moisture and test Weight
            let incomingLoad = new NewLoadMoistureTestWeight();
            incomingLoad.moistureLevel = moisture;
            incomingLoad.testWeight = testWeight;
            load = incomingLoad;
          }
        }
        else {
          // Only Moisture
          let incomingLoad = new NewLoadMoisture();
          incomingLoad.moistureLevel = moisture;
          load = incomingLoad;
        }
      }
    }

    this.load = load
    // Post load
    this.loadService.post(this.load);
    console.log(load);
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
