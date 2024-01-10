import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { NewWeightsheetComponent } from '../new-weightsheet/new-weightsheet.component';


@Component({
  selector: 'app-new-load',
  templateUrl: './new-load.component.html',
  styleUrls: ['./new-load.component.scss']
})
export class NewLoadComponent {
  constructor(public weightsheetDialog: MatDialog, public dialogRef: MatDialogRef<NewLoadComponent>) { }

  openNewWeightsheetDialog(): void {
    const dialogConfig = new DialogConfig();

    let dialogRef = this.weightsheetDialog.open(NewWeightsheetComponent, {
      width: '350px'
    });
  }

  onCancel(): void { 
    this.dialogRef.close();
  }
}
