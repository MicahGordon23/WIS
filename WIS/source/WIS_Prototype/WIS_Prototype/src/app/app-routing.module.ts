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

//import { WarehouseComponent } from './warehouse/warehouse.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'lot', component: LotComponent },
  { path: 'load', component: LoadComponent },
  { path: 'weightsheet', component: WeightsheetComponent },
  { path: 'lot/:id', component: EditLotComponent },
  { path: 'load/:id', component: EditLoadComponent },
  { path: 'weightsheet/:id', component: EditWeightsheetComponent },
  { path: 'report', component: ReportComponent },
  { path: 'daily-ws/:id', component: DailyWeightSheetReportComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
