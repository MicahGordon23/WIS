import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { NewWeightsheetComponent } from '../weightsheet/new-weightsheet.component';

import { Load } from './load';
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
    private http: HttpClient
    //private loadService: LoadService
  ) { }

  // The form model
  form!: FormGroup;

  // the new load ref
  load!: Load;

  bins!: Bin[];

  ngOnInit() {

    this.form = new FormGroup({
      truckId: new FormControl(''),
      moistureLevel: new FormControl(''),
      testWeight: new FormControl(''),
      protinLevel: new FormControl(''),
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
      load.protienLevel = this.form.controls['proteinLevel'].value;
      load.bolNumber = this.form.controls['bolNumber'].value;
      load.notes = this.form.controls['notes'].value;
    }
    // put load
    this.http.post<Load>('api/Loads', load);
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


  //addload(l: Load): Observable<Load> {
  //  return this.http.post<Load>('/api/Load', l))
  //  )
  //}
}
