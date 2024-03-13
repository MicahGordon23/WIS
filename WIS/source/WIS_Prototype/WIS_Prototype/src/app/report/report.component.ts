import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

// npm i xlsx
import * as XLSX from "xlsx";


import { Observable } from 'rxjs';
import { getLocaleDateFormat } from '@angular/common';


@Component({
  selector: 'app-intake-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent {

  warehouseId: number;
  
  constructor(
    private route: Router
  ) {
    this.warehouseId = 1;
  }

  getIntakeReport(): void {
    this.route.navigate(['report/intake/' + this.warehouseId]);
  }

  genWeightSheetReport(): void {
    this.route.navigate(['/report/daily-ws/' + this.warehouseId]);
  }

  genCommodityReport(): void {
    this.route.navigate(['report/daily-commodity/' + this.warehouseId]);
  }

  genProducerReport(): void {
    this.route.navigate(['report/producer-commodity/' + this.warehouseId]);
  }

  genTransferReport(): void {
    this.route.navigate(['report/transfer/' + this.warehouseId]);
  }
}
