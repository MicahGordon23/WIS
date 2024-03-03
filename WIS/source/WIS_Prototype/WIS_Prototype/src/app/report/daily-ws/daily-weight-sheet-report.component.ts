import { Component } from '@angular/core';

// npm i xlsx
import * as XLSX from "xlsx";

import { WeightSheetReport } from '../weight-sheet-report';

import { ReportService } from '../report-service';

import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-daily-weight-sheet-report',
  templateUrl: './daily-weight-sheet-report.component.html',
  styleUrls: ['./daily-weight-sheet-report.component.scss']
})
export class DailyWeightSheetReportComponent {
  report!: WeightSheetReport[];

  netLoads: number;

  netWeight: number;

  constructor(
    private reportService: ReportService,
    private activeRouter: ActivatedRoute,
    private route: Router
  ) {
    this.netLoads = 0;
    this.netWeight = 0;
  }

  ngOnInit() {
    this.reportService.getDailyWeightSheetReport(1)
      .subscribe(result => {
        this.report = result;
        this.calcNets();
        console.log(this.report);
      }, e => console.log(e));
  }

  calcNets(): void {
    for (let i = 0; i < this.report.length; i++) {
      this.netLoads += this.report[i].loadsOnSheet;
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
