import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { NewLoadComponent } from '../load/new-load.component';

import { WeightsheetOverview } from '../weightsheet/weightsheet';
import { WeightsheetService } from '../weightsheet/weightsheet.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {

  weightsheets!: WeightsheetOverview[];
  constructor(
    private weightsheetService: WeightsheetService,
    public loadDialog: MatDialog
  ) { }

  ngOnInit() {
    this.weightsheetService.getOverview(1)
      .subscribe(result => {
        this.weightsheets = result;
      }, e => console.log(e));
  }

  //openNewLoadDialog(): void
  //{
  //  // Used to configure dialog options like height, width, ect.
  //  const dialogConfig = new DialogConfig();

  //  let dialogRef = this.loadDialog.open(NewLoadComponent, {
     
  //  });
  //}

}
