import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { NewLotComponent } from '../lot/new-lot.component'
import { Weightsheet } from './weightsheet';

@Component({
  selector: 'app-new-weightsheet',
  templateUrl: './new-weightsheet.component.html',
  styleUrls: ['./new-weightsheet.component.scss']
})
export class NewWeightsheetComponent {
  constructor(
    private lotDialog: MatDialog,
    private dialogRef: MatDialogRef<NewWeightsheetComponent>,
    private http: HttpClient
  ) { }

  form!: FormGroup;

  weightsheet!: Weightsheet;

  ngOnInit() {
    this.form = new FormGroup({
      weigher: new FormControl(''),
      hauler: new FormControl(''),
      miles: new FormControl(''),
      billofLading: new FormControl(''),
      notes: new FormControl('')
    })
  }

  openNewLotDialog(): void {
    const dialogConfig = new DialogConfig();
    let dialogRef = this.lotDialog.open(NewLotComponent, {});
  }

  onSubmit() {

  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
