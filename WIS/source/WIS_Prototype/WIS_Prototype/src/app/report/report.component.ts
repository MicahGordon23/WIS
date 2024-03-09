import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

// npm i xlsx
import * as XLSX from "xlsx";



import { IntakeReport } from './intake-report';
import { ReportService } from './report-service';

import { Producer } from '../producer/producer';
import { ProducerService } from '../producer/producer.service';

import { CommodityType } from '../commodity-type/commodity-type';
import { CommodityTypeService } from '../commodity-type/commodity-type.service';

import { CommodityVariety } from '../commodity-variety/commodity-variety';
import { CommodityVarietyService } from '../commodity-variety/commodity-variety.service';

import { Observable } from 'rxjs';
import { getLocaleDateFormat } from '@angular/common';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent {
  public displayColumns: string[] = ['Column1 WeightshetId', 'Lot Id', 'Producer Name', 'Producer Number'];
  public report!: IntakeReport[];
  public producers!: Producer[];
  public commodityTypes!: CommodityType[];
  public commodityVarieties!: CommodityVariety[];
  // Work around because JS is BS. Changing object types losing Methodes and properties.
  public lotsClosed: string[];
  bushelConversion: number;
  warehouseId: number;
  public netWarehouseIntakeLbs: number;
  
  constructor(
    private reportService: ReportService,
    private producerService: ProducerService,
    private commodityTypeService: CommodityTypeService,
    private commodityVarietyService: CommodityVarietyService,
    private route: Router
  )
  {
    this.lotsClosed = new Array<string>();
    this.bushelConversion = 60;
    this.netWarehouseIntakeLbs = 0;
    this.warehouseId = 1;
  }

  ngOnInit() {
    this.producerService.getData()
      .subscribe(result => {
        this.producers = result;
        console.log(this.producers);
      }, error => console.error(error));

    this.commodityTypeService.getData()
      .subscribe(result => {
        this.commodityTypes = result;
      }, error => console.error(error));

    this.commodityVarietyService.getData()
      .subscribe(result => {
        this.commodityVarieties = result;
      }, error => console.error(error));
  }

  checkClosed(r: IntakeReport): string {
    if (r.endDate == null) {
      return r.isClosedString = "Open";
    }
    else {
      return r.isClosedString = "Closed";
    }
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

  getIntakeReport(): void {
    this.reportService.getIntakeReport(this.warehouseId)
      .subscribe(result => {
       
        console.log(result);
        this.report = result;
        // JavaScript is hell and should die in a hole
        // Changing from this.report[i] IntakeReport object to just a object created from the
        //  Raw JSON file cause fk you thats why.
        for (let i = 0; i < this.report.length; i++) {
          
          this.lotsClosed.push(this.checkClosed(this.report[i]));
          if (this.report[i].netWeightLbs != 0) {
            // Set up for only Bushel conversion
            this.report[i].netUom = Math.trunc(this.report[i].netWeightLbs / this.bushelConversion);
          }
          else {
            this.report[i].netUom = 0;
          }
         
          // Tech Debt: Make
          // This abomination will be repeated for Commodity Name and Variety.
          for (let j = 0; j < this.producers.length; j++) {
            if (this.report[i].producerIdLink == this.producers[j].producerId) {
              this.report[i].producerName = this.producers[j].producerName;
            }
          }

          // Tech Debt: effiency
          for (let a = 0; a < this.commodityTypes.length; a++) {
            if (this.report[i].commodityTypeIdLink == this.commodityTypes[a].commodityTypeId) {
              this.report[i].commodityTypeName = this.commodityTypes[a].commodityTypeName;
            }
          }

          // Thec Debt: efficency
          for (let b = 0; b < this.commodityVarieties.length; b++) {
            if (this.report[i].commodityVarietyIdLink != null) {
              if (this.report[i].commodityVarietyIdLink == this.commodityVarieties[b].commodityVarietyId) {
                this.report[i].commodityVarietyName = this.commodityVarieties[b].commodityVarietyName;
              }
            }
           
          }
          // Create netweight
          this.netWarehouseIntakeLbs += this.report[i].netWeightLbs; 
        }
        console.log(this.report);
      }, error => console.error(error));
  }

  exportToExcel() {
    //let obj = {};
    //this.report.forEach(item => obj[item.Field] = time.Value);
    const json = JSON.stringify(this.report);
    const data = JSON.parse(json);
    const columns = this.getColumns(data);
    const worksheet = XLSX.utils.json_to_sheet(data, { header: columns });
    const workbook = XLSX.utils.book_new();
    const date = new Date();
    const dateStr = date.toLocaleDateString().replaceAll('/','-');
    //dateStr.replace('.', '/');
    XLSX.utils.book_append_sheet(workbook, worksheet, "Intake Report " + dateStr);
    XLSX.writeFile(workbook, "IntakeReport" + dateStr + ".xlsx");
  }

  getColumns(data: any[]): string[] {
    const columns: any = [];
    data.forEach(row => {
      Object.keys(row).forEach(col => {
        if (!columns.includes(col)) {
          columns.push(col);
        }
      });
    });
    return columns
  }
}
