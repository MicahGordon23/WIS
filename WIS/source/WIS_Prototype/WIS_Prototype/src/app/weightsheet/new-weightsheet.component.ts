import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import {NewLotComponent } from '../lot/new-lot.component'

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

  openNewLotDialog(): void {
    const dialogConfig = new DialogConfig();
    let dialogRef = this.lotDialog.open(NewLotComponent, {});
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
