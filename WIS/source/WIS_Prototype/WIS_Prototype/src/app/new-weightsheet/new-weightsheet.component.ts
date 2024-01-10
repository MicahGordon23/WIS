import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-new-weightsheet',
  templateUrl: './new-weightsheet.component.html',
  styleUrls: ['./new-weightsheet.component.scss']
})
export class NewWeightsheetComponent {
  constructor (public dialogRef: MatDialogRef<NewWeightsheetComponent>) { }

  onCancel(): void {
    this.dialogRef.close();
  }
}
