import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfig } from '@angular/cdk/dialog';
import { NewLoadComponent } from '../new-load/new-load.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {
  constructor(public loadDialog: MatDialog) { }

  openNewLoadDialog(): void
  {
    // Used to configure dialog options like height, width, ect.
    const dialogConfig = new DialogConfig();

    let dialogRef = this.loadDialog.open(NewLoadComponent, {
      width: '350px'
    });
  }

}
