import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

// npm i xlsx
import * as XLSX from "xlsx";

import { CommodityReport } from '../daily-commodity-report';

import { ReportService } from '../report-service';

@Component({
  selector: 'app-daily-commodity-report',
  templateUrl: './daily-commodity-report.component.html',
  styleUrls: ['./daily-commodity-report.component.scss']
})
export class DailyCommodityReportComponent {
  report!: CommodityReport[];
  sumLoads: number;
  constructor(
    private reportService: ReportService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {
    this.sumLoads = 0;
  }

  ngOnInit() {
    // Get the warehouseId using id from the route.
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    let warehouseId = idParam ? +idParam : 0;
    this.reportService.getDailyCommodityReport(warehouseId)
      .subscribe(result => {
        this.report = result;
        this.calcNetLoads();
      }, error => console.log(error));
  }

  calcNetLoads(): void {
    for (let i = 0; i < this.report.length; i++) {
      this.sumLoads += this.report[i].numLoads;
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
    XLSX.utils.book_append_sheet(workbook, worksheet, "Daily Weight Sheet" + dateStr);
    XLSX.writeFile(workbook, "DailyWeightSheet" + dateStr + ".xlsx");
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
