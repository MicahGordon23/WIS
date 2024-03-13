import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

// Imports for all Materal modules here
import { AngularMaterialModule } from './angular-material.module';

// Components
import { AppComponent } from './app.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { WeightsheetComponent } from './weightsheet/weightsheet.component';
import { EditWeightsheetComponent } from './weightsheet/edit-weightsheet/edit-weightsheet.component';
import { LoadComponent } from './load/load.component';
import { EditLoadComponent } from './load/edit-load/edit-load.component';
import { LotComponent } from './lot/lot.component';
import { EditLotComponent } from './lot/edit-lot/edit-lot.component';
import { NewLoadComponent } from './load/new-load.component';
import { NewWeightsheetComponent } from './weightsheet/new-weightsheet.component';
import { NewLotComponent } from './lot/new-lot.component';
import { ReportComponent } from './report/report.component';
import { IntakeReportComponent } from './report/intake/intake-report.component';
import { DailyWeightSheetReportComponent } from './report/daily-ws/daily-weight-sheet-report.component';
import { DailyCommodityReportComponent } from './report/daily-commodity/daily-commodity-report.component';
import { ProducerCommodityReportComponent } from './report/producer-commodity/producer-commodity-report.component';
import { TransferReportComponent } from './report/transfer/transfer-report.component';
import { NewWsDialogComponent } from './dialogs/new-ws-dlog/new-ws-dialog.component';
import { OpenLotsDialogComponent } from './dialogs/open-lot-dlog/open-lots-dialog.component';
import { NewInboundWsComponent } from './weightsheet/new-inbound/new-inbound-ws.component';
import { NewTransferWsComponent } from './weightsheet/new-transfer/new-transfer-ws.component';

// Services
import { LoadService } from './load/load.service';
import { WeightsheetService } from './weightsheet/weightsheet.service';
import { ProducerService } from './producer/producer.service';
import { LotService } from './lot/lot.service';
import { CommodityTypeService } from './commodity-type/commodity-type.service';
import { CommodityVarietyService } from './commodity-variety/commodity-variety.service';
import { BinService } from './bin/bin.service';
import { TruckScaleService } from './scale/truck-scale.service';
import { ReportService } from './report/report-service';
import { SourceService } from './source/source.service';

@NgModule({
  declarations: [
    AppComponent,
    WarehouseComponent,
    HomeComponent,
    NavMenuComponent,
    WeightsheetComponent,
    EditWeightsheetComponent,
    LoadComponent,
    EditLoadComponent,
    LotComponent,
    EditLotComponent,
    NewLoadComponent,
    NewWeightsheetComponent,
    NewWsDialogComponent,
    NewLotComponent,
    ReportComponent,
    IntakeReportComponent,
    DailyWeightSheetReportComponent,
    DailyCommodityReportComponent,
    ProducerCommodityReportComponent,
    TransferReportComponent,
    OpenLotsDialogComponent,
    NewInboundWsComponent,
    NewTransferWsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NoopAnimationsModule,
    ReactiveFormsModule,
    AngularMaterialModule
  ],

  providers: [
    LoadService,
    WeightsheetService,
    ProducerService,
    LotService,
    CommodityTypeService,
    CommodityVarietyService,
    BinService,
    TruckScaleService,
    ReportService,
    SourceService
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
