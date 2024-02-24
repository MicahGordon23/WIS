import { Component, OnInit } from '@angular/core';

import { IntakeReport } from './intake-report';
import { ReportService } from './report-service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent {
  public displayColumns: string[] = ['Column1 WeightshetId', 'Lot Id', 'Producer Name', 'Producer Number'];
  public report!: IntakeReport[];
  // Work around because JS is BS. Changing object types losing Methodes and properties.
  public lotsClosed: string[];

  CheckClosed(r: IntakeReport): string {
    if (r.lotEndDate == null) {
      return r.isClosedString = "Open";
    }
    else {
      return r.isClosedString = "Closed";
    }
  }
  constructor(
    private reportService: ReportService
  )
  {
    this.lotsClosed = new Array<string>();
  }

  getIntakeReport(): void {
    this.reportService.getIntakeReport(1)
      .subscribe(result => {
       
        console.log(result);
        this.report = result;
        // JavaScript is hell and should die in a hole
        // Changing from this.report[i] IntakeReport object to just a object created from the
        //  Raw JSON file cause fk you thats why.
        for (let i = 0; i < this.report.length; i++) {
          this.lotsClosed.push(this.CheckClosed(this.report[i]));
        }
        
        console.log(this.report);
      }, error => console.error(error));
  }
}
