import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';

import { OpenLotsDialogComponent } from '../open-lot-dlog/open-lots-dialog.component';

@Component({
  selector: 'app-new-ws-dialog',
  templateUrl: './new-ws-dialog.component.html',
  styleUrls: ['./new-ws-dialog.component.scss']
})
export class NewWsDialogComponent {
  warehouseId: number;
  constructor(
    private lotsDialog: MatDialog,
    private router: Router,
    private dialogRef: MatDialogRef<NewWsDialogComponent>,
  ) {
    this.warehouseId = 1;
  }

  selectTransferWeightSheet() {
    this.router.navigate(['']);
    this.dialogRef.close();
  }

  selectInboundWeightSheet() {
    const dialogConfig = new DialogConfig();
    let dialogRef = this.lotsDialog.open(OpenLotsDialogComponent, {});
    this.dialogRef.close();
  }
}
