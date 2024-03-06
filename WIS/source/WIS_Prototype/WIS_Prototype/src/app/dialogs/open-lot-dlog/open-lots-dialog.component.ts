import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

import { LotDto } from '../../lot/lot';
import { LotService } from '../../lot/lot.service';

@Component({
  selector: 'app-open-lots-dialog',
  templateUrl: './open-lots-dialog.component.html',
  styleUrls: ['./open-lots-dialog.component.scss']
})
export class OpenLotsDialogComponent {
  warehouseId: number;

  lots!: LotDto[];
  constructor(
    private lotService: LotService,
    private dialogRef: MatDialogRef<OpenLotsDialogComponent>,
  ) {
    this.warehouseId = 1;
  }

  ngOnInit() {
    this.lotService.getOpenLotsByWarehouse(this.warehouseId)
      .subscribe(result => {
        this.lots = result;
        console.log(this.lots);
      }, error => console.log(error));
  }

}
