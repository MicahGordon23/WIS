import { Component } from '@angular/core';
// npm i xlsx
import * as XLSX from "xlsx";
import { ProducerReport } from '../producer-report';
import { ReportService } from '../report-service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-producer-commodity-report',
  templateUrl: './producer-commodity-report.component.html',
  styleUrls: ['./producer-commodity-report.component.scss']
})
export class ProducerCommodityReportComponent {
  report!: ProducerReport[];

  netLoads: number;

  netWeight: number;

  warehouseId: number;

  constructor(
    private reportService: ReportService,
    private activatedRoute: ActivatedRoute,
  ) {
    this.netLoads = 0;
    this.netWeight = 0;
    this.warehouseId = 1;
  }

  ngOnInit() {
    // Get the lot using id from the route.
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.warehouseId = idParam ? +idParam : 0;

    this.reportService.getDailyProducerCommodityReport(this.warehouseId)
      .subscribe(result => {
        this.report = result;
        console.log(this.report);
        this.calcNets()
      }, error => console.log(error));
  }

  calcNets(): void {
    for (let i = 0; i < this.report.length; i++) {
      this.netLoads += this.report[i].sumLoads;
      this.netWeight += this.report[i].netWeightLbs;
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
    XLSX.utils.book_append_sheet(workbook, worksheet, "Producer Commodity Report" + dateStr);
    XLSX.writeFile(workbook, "ProducerCommodityReport" + dateStr + ".xlsx");
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
