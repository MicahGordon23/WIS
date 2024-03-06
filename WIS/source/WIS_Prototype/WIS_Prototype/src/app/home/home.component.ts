import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { NewWsDialogComponent } from '../dialogs/new-ws-dlog/new-ws-dialog.component';

import { WeightsheetOverview } from '../weightsheet/weightsheet';
import { WeightsheetService } from '../weightsheet/weightsheet.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {
  warehouseId: number;
  weightsheets!: WeightsheetOverview[];
  constructor(
    private weightsheetService: WeightsheetService,
    private router: Router,
    public newWeightSheet: MatDialog
  ) {
    this.warehouseId = 1;
  }

  ngOnInit() {
    this.weightsheetService.getOverview(this.warehouseId)
      .subscribe(result => {
        this.weightsheets = result;
        console.log(this.weightsheets);
      }, e => console.log(e));
  }

  //newWeightSheet() {
  //  this.router.navigate(['/new-weightsheet/' + this.warehouseId]);
  //}

  newLot() {
    this.router.navigate(['/new-lot/'+ this.warehouseId])
  }

  openNewWeightSheetDialog(): void {
    const dialogConfig = new DialogConfig();

    let dialogRef = this.newWeightSheet.open(NewWsDialogComponent, {

    });
  }
}
