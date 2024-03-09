/*****************************************************
 *  Having a sperate app-routing module is consiterded to be best practice.
 *  The other option is to put it in app.module.ts, but NOT best practice.
*****************************************************/

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LotComponent } from './lot/lot.component';
import { LoadComponent } from './load/load.component';
import { EditLoadComponent } from './load/edit-load/edit-load.component';
import { WeightsheetComponent } from './weightsheet/weightsheet.component';
import { ReportComponent } from './report/report.component';
import { EditLotComponent } from './lot/edit-lot/edit-lot.component';
import { EditWeightsheetComponent } from './weightsheet/edit-weightsheet/edit-weightsheet.component';
import { DailyWeightSheetReportComponent } from './report/daily-ws/daily-weight-sheet-report.component';
import { DailyCommodityReportComponent } from './report/daily-commodity/daily-commodity-report.component';
import { NewLoadComponent } from './load/new-load.component';
import { NewWeightsheetComponent } from './weightsheet/new-weightsheet.component';
import { NewLotComponent } from './lot/new-lot.component';
import { NewInboundWsComponent } from './weightsheet/new-inbound/new-inbound-ws.component';
import { ProducerCommodityReportComponent } from './report/producer-commodity/producer-commodity-report.component';

//import { WarehouseComponent } from './warehouse/warehouse.component';
// Could add warehouse ID to all of these tbh.

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'lot', component: LotComponent },
  { path: 'load', component: LoadComponent },
  { path: 'weightsheet', component: WeightsheetComponent },
  { path: 'lot/:id', component: EditLotComponent },   // Lot Id number
  { path: 'load/:id', component: EditLoadComponent }, // Load Id number
  { path: 'weightsheet/:id', component: EditWeightsheetComponent },   // Weight Sheet Id number
  { path: 'report', component: ReportComponent },
  { path: 'report/daily-ws/:id', component: DailyWeightSheetReportComponent }, // Warehouse Id number
  { path: 'report/daily-commodity/:id', component: DailyCommodityReportComponent }, // Warehouse Id
  { path: 'report/producer-commodity/:id', component: ProducerCommodityReportComponent }, // Warehouse Id
  { path: 'new-load/:id', component: NewLoadComponent },    // Weight Sheet Id number
  { path: 'new-weightsheet/:id', component: NewWeightsheetComponent }, // Warehouse Id number
  { path: 'new-lot/:id', component: NewLotComponent }, // Warehouse Id number
  { path: 'new-inbound-weightsheet/:id', component: NewInboundWsComponent } // Lot Id number
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
