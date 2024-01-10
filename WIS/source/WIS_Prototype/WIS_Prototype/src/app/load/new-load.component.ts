import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { NewWeightsheetComponent } from '../new-weightsheet/new-weightsheet.component';
import { Load } from '../load/load';
//import { LoadComponent } from 'load.component';

@Component({
  selector: 'app-new-load',
  templateUrl: './new-load.component.html',
  styleUrls: ['./new-load.component.scss']
})
export class NewLoadComponent {
  constructor(
    public weightsheetDialog: MatDialog,
    public dialogRef: MatDialogRef<NewLoadComponent>,
    private http:HttpClient // Future use in post request?
  ) {
  }

  openNewWeightsheetDialog(): void {
    const dialogConfig = new DialogConfig();

    let dialogRef = this.weightsheetDialog.open(NewWeightsheetComponent, {
      width: '350px'
    });
  }

  onCancel(): void { 
    this.dialogRef.close();
  }

  // The form model
  form!: FormGroup;

  // the new load ref
  load?: Load;

  ngOnInit() {
    this.form = new FormGroup({
      truckId: new FormControl(''),
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protienLevel: new FormControl(''),
      bolNumber: new FormControl(''),
      notes: new FormControl('')
    });
  }

  onSubmit() {
    var load = this.load;
    if (load) {
      // generate load id? or do this before for when clicking new laod?
      // Controller gets the id service does the math
      // Http Get from scale. Scale Service/Controller Most likely a controller here
      load.truckId = this.form.controls['truckId'].value;
      load.timeIn = new Date();
      load.moistureLevel = this.form.controls['moistureLevel'].value;
      load.testWeight = this.form.controls['testWeight'].value;
      load.proteinLevel = this.form.controls['proteinLevel'].value;
      load.bolNumber = this.form.controls['bolNumber'].value;
      load.notes = this.form.controls['notes'].value;
    }

    console.log(load);
    this.dialogRef.close();
  }
}
