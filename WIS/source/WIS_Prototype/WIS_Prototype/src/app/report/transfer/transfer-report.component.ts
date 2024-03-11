import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

// npm i xlsx
import * as XLSX from "xlsx";

import { TransferReport } from '../transfer-report';
import { ReportService } from '../report-service';



@Component({
  selector: 'app-transfer-report',
  templateUrl: './transfer-report.component.html',
  styleUrls: ['./transfer-report.component.scss']
})
export class TransferReportComponent {
  report!: TransferReport[];
  sumLoads: number;
  netWeight: number;

  constructor(
    private reportService: ReportService,
    private activatedRoute: ActivatedRoute,
  ) {
    this.sumLoads = 0;
    this.netWeight = 0;
  }

  ngOnInit() {
    // Get the warehouseId using id from the route.
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    let warehouseId = idParam ? +idParam : 0;
    this.reportService.getTransferReport(warehouseId)
      .subscribe(result => {
        this.report = result;
        console.log(this.report);
        this.calcNetLoadsWeight();
      }, error => console.log(error));
  }

  calcNetLoadsWeight(): void {
    for (let i = 0; i < this.report.length; i++) {
      this.sumLoads += this.report[i].numLoads;
      this.netWeight += this.report[i].netWeight;
    }
  }

  exportToExcel(): void {
    const json = JSON.stringify(this.report);
    const data = JSON.parse(json);
    const columns = this.getColumns(data);
    const worksheet = XLSX.utils.json_to_sheet(data, { header: columns });
    const workbook = XLSX.utils.book_new();
    const date = new Date();
    const dateStr = date.toLocaleDateString().replaceAll('/', '-');
    //dateStr.replace('.', '/');
    XLSX.utils.book_append_sheet(workbook, worksheet, "Transfer" + dateStr);
    XLSX.writeFile(workbook, "Transfer" + dateStr + ".xlsx");
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
