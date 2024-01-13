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

// Services
import { LoadService } from './load/load.service';
import { WeightsheetService } from './weightsheet/weightsheet.service';


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
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NoopAnimationsModule,
    ReactiveFormsModule,
    AngularMaterialModule
  ],

  providers: [ LoadService, WeightsheetService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
