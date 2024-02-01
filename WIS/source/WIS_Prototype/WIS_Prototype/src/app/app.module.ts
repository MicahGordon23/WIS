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
import { LoadComponent } from './load/load.component';
import { LotComponent } from './lot/lot.component';
import { NewLoadComponent } from './load/new-load.component';
import { NewWeightsheetComponent } from './weightsheet/new-weightsheet.component';
import { NewLotComponent } from './lot/new-lot.component';
import { EditLoadComponent } from './load/edit-load/edit-load.component';

// Services
import { LoadService } from './load/load.service';
import { WeightsheetService } from './weightsheet/weightsheet.service';
import { ProducerService } from './producer/producer.service';
import { LotService } from './lot/lot.service';
import { CommodityTypeService } from './commodity-type/commodity-type.service';
import { CommodityVarietyService } from './commodity-variety/commodity-variety.service';
import { BinService } from './bin/bin.service';
import { TruckScaleService } from './scale/truck-scale.service';

@NgModule({
  declarations: [
    AppComponent,
    WarehouseComponent,
    HomeComponent,
    NavMenuComponent,
    WeightsheetComponent,
    LoadComponent,
    LotComponent,
    NewLoadComponent,
    NewWeightsheetComponent,
    NewLotComponent,
    EditLoadComponent
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
    TruckScaleService
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
